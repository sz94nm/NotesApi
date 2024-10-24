using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesApi.DTOs;

namespace NotesApi.Models
{
    public class Tag
    {

        public int Id { get; set; }                  // Unique identifier for the tag
        public string Name { get; set; }              // Name of the tag
        public ICollection<Note> Notes { get; set; }         // Navigation property for related notes


    }
}