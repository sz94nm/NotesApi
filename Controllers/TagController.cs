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
using NotesApi.Services;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITagService _tagService;
        public
        TagController(AppDbContext appDbContext, ITagService tagService)
        {
            _appDbContext = appDbContext;
            _tagService = tagService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagService.GetAll();

            return Ok(tags);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var tag = await _tagService.GetById(id);
            if (tag == null) return BadRequest("tag not found");
            return Ok(tag);


        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagCreateDto tag)
        {
            if (tag == null) return BadRequest("name can not be empty");
            var t = new Tag();

            t.Name = tag.Name;
            var res = await _tagService.Create(t);
            if (!res) return StatusCode(500, "something happend");
            return Ok("created successfully ");

        }



        [HttpDelete("id")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var tag = await _tagService.GetById(id);
            if (tag == null) { return NotFound("tag does not exist"); }

            var res = await _tagService.Delete(id);
            if (!res) return StatusCode(500, "something happend ");
            return NoContent();

        }
        [HttpPatch("id")]
        public async Task<IActionResult> Update(int id, TagUpdateDto newTag)
        {
            var tag = await _appDbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (tag == null) { return NotFound(); }


            tag.Name = newTag.Name;
            var res = await _tagService.Update(tag);
            if (!res) return StatusCode(500, "something happend ");

            return Ok("updated successfully");
        }
    }
}