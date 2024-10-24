using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.DTOs;
using NotesApi.Interfaces;
using NotesApi.Models;

namespace NotesApi.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _appDbContext;

        public NoteService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<IEnumerable<NoteReadDto>> GetAll()
        {
            var notes = _appDbContext.Notes
            .Select(note => new NoteReadDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                Tag = new TagReadDto
                {
                    Id = note.Tag.Id,
                    Name = note.Tag.Name
                },
                User = new UserReadDto
                {
                    Id = note.User.Id,
                    Username = note.User.Username,
                    Email = note.User.Email,
                }
            }).ToList();
            return notes;
        }

        public async Task<NoteReadDto> GetById(int id)
        {
            var note = await _appDbContext.Notes.Where(note => note.Id == id)
            .Select(note => new NoteReadDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                Tag = new TagReadDto
                {
                    Id = note.Tag.Id,
                    Name = note.Tag.Name
                },
                User = new UserReadDto
                {
                    Id = note.User.Id,
                    Username = note.User.Username,
                    Email = note.User.Email,
                }
            }).FirstOrDefaultAsync();

            return note;
        }
        public async Task<bool> Create(Note note)
        {
            try
            {
                await _appDbContext.Notes.AddAsync(note);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;

            }


        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _appDbContext.Notes.Where(n => n.Id == id).ExecuteDeleteAsync();
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Note note)
        {
            try
            {
                

                _appDbContext.Notes.Update(note);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}