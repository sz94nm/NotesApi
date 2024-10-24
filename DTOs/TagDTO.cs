using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.DTOs
{
    public class TagCreateDto
    {
        public string Name { get; set; }
    }

    public class TagReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TagUpdateDto
    {
        public string Name { get; set; }
    }
}