using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }        // Username for registration
        public string Email { get; set; }           // Email for registration
    }
}