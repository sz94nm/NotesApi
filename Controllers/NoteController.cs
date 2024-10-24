using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.DTOs;
using NotesApi.Interfaces;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly INoteService _noteService;
        private readonly ITagService _tagService;
        public NoteController(AppDbContext appDbContext, INoteService noteService, ITagService tagService)
        {
            _appDbContext = appDbContext;
            _noteService = noteService;
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteService.GetAll();

            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NoteCreateDto note)
        {
            //validation
            if (note.Title == null || note.Content == null || note.TagId == null)
                return BadRequest("fields must not be empty ");


            if (await _tagService.GetById(note.TagId) == null)
                return BadRequest("tag id doesnt exist");
            // if (await _userService.GetById(note.UserId) == null)
            //     return BadRequest("user id doesnt exist");

            //assigning dto to note
            Note newNote = new Note();
            newNote.Title = note.Title;
            newNote.Content = note.Content;
            newNote.TagId = 1;
            newNote.UserId = 1;

            var res = await _noteService.Create(newNote);
            if (!res) return StatusCode(500, "something happend");
            return Ok("created successfully ");


        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _noteService.GetById(id);
            if (note == null)
                return BadRequest("note doesnt exist");

            var res = await _noteService.Delete(id);
            if (!res) return StatusCode(500, "something happend");
            return Ok("Deleted Successfully");

        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, [FromBody] NoteCreateDto note)
        {
            //validation
            // if (note)
            //     return BadRequest("fields must not be empty ");
            if (note.TagId != null && await _tagService.GetById(note.TagId) == null)
                return BadRequest("tag id doesnt exist");
            if (note.UserId != null && await _tagService.GetById(note.UserId) == null)
                return BadRequest("user id doesnt exist");


            //assigning dto to note
            Note newNote = new Note();
            if (note.Title != null)
                newNote.Title = note.Title;
            if (note.Content != null)
                newNote.Content = note.Content;
            if (note.TagId != null)
                newNote.TagId = note.TagId;
            if (note.UserId != null)
                newNote.UserId = note.UserId;

            var res = await _noteService.Update(newNote);
            if (!res) return StatusCode(500, "something happend");
            return Ok("updated successfully ");
        }


    }
}