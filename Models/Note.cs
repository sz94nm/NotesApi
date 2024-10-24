using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Models
{
    public class Note
    {

        public int Id { get; set; }                  // Unique identifier for the note
        public string Title { get; set; }            // Title of the note
        public string Content { get; set; }          // Content of the note
        public DateTime CreatedAt { get; set; }      // Date the note was created
        public DateTime UpdatedAt { get; set; }      // Date the note was last updated
        public int UserId { get; set; }              // Foreign key to the user
        public int TagId { get; set; }




        [ForeignKey("UserId")]
        public User User { get; set; }               // Navigation property to the user
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }                 // Tag associated with the note
    }
}