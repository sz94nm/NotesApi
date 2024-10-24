using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NotesApi.Models;

namespace NotesApi.DTOs
{
    public class NoteReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Title of the note
        public string Content { get; set; }          // Content of the note
        public TagReadDto Tag { get; set; }
        public UserReadDto User { get; set; }       // Tags for the note
    }

    public class NoteCreateDto
    {

        public string Title { get; set; }            // Title of the note
        public string? Content { get; set; }          // Content of the note
        public int TagId { get; set; }
        public int UserId { get; set; }       // Tags for the note
    }
}