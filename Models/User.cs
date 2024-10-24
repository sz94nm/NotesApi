using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesApi.DTOs;

namespace NotesApi.Models
{
    public class User

    {
        public int Id { get; set; }                 // Unique identifier for the user
        public string Username { get; set; }        // Username for login
        public string PasswordHash { get; set; }    // Hashed password
        public string Email { get; set; }           // User's email address
        public DateTime CreatedAt { get; set; }     // Date the user was created
        public ICollection<Note> Notes { get; set; }       // Navigation property for related notes


    }
}