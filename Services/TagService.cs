using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.DTOs;
using NotesApi.Interfaces;
using NotesApi.Models;

namespace NotesApi.Services
{

    public class TagService : ITagService
    {

        private readonly AppDbContext _appDbContext;
        public TagService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TagReadDto>> GetAll()
        {
            var tags = await _appDbContext.Tags.Select(t => new TagReadDto
            {
                Id = t.Id,
                Name = t.Name,

            }).ToListAsync();

            return tags;
        }

        public async Task<TagReadDto> GetById(int id)
        {
            var tag = await _appDbContext.Tags.Where(t => t.Id == id).Select(t => new TagReadDto
            {
                Id = t.Id,
                Name = t.Name,

            }).FirstOrDefaultAsync();

            return tag;
        }
        public async Task<bool> Create(Tag tag)
        {
            try
            {
                await _appDbContext.Tags.AddAsync(tag);
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
                _appDbContext.Tags.Where(t => t.Id == id).ExecuteDeleteAsync();
                await _appDbContext.SaveChangesAsync();
                return true;

            }
            catch (System.Exception)
            {
                return false;

            }

        }

        public async Task<bool> Update(Tag tag)
        {
            try
            {
                _appDbContext.Tags.Update(tag);
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