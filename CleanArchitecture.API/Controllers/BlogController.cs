﻿using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {

			_blogService = blogService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var blogs = await _blogService.GetAllAsync();
			return Ok(blogs);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var blog = await _blogService.GetByIdAsync(id);
			if (blog == null)
			{
				return NotFound();
			}
			return Ok(blog);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Blog blog)
		{
			var newBlog = await _blogService.CreateAsync(blog);
			return CreatedAtAction(nameof(GetById), new { id = newBlog.Id }, newBlog);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Blog blog)
		{
			var result = await _blogService.UpdateAsync(id, blog);
			if (result == 0)
			{
				return BadRequest();
			}
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _blogService.DeleteAsync(id);
			if (result == 0)
			{
				return BadRequest();
			}
			return NoContent();
		}
	}
}
