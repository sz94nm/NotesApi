using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesApi.DTOs;
using NotesApi.Models;

namespace NotesApi.Interfaces
{
    public interface INoteService
    {
        public Task<IEnumerable<NoteReadDto>> GetAll();
        public Task<NoteReadDto> GetById(int id);
        public Task<bool> Create(Note note);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Note note);
    }
}