using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesApi.DTOs;
using NotesApi.Models;

namespace NotesApi.Interfaces
{
    public interface ITagService
    {
        public Task<IEnumerable<TagReadDto>> GetAll();
        public Task<TagReadDto> GetById(int id);
        public Task<bool> Create(Tag tag);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Tag tag);
    }
}