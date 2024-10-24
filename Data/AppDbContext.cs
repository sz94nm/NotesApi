
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NotesApi.Models;

namespace NotesApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



    }
}