﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
	public class BlogRepository : IBlogRepository
	{
		private readonly BlogDbContext _DbContext;
		public BlogRepository(BlogDbContext blogDbContext)
		{
			_DbContext = blogDbContext;
		}

		public async Task<List<Blog>> GetAllAsync()
		{
			return await _DbContext.Blogs.ToListAsync();
		}

		public async Task<Blog> GetByIdAsync(int id)
		{
			return await _DbContext.Blogs.AsNoTracking()
				.FirstOrDefaultAsync(b => b.Id == id);
		}
		public async Task<Blog> CreateAsync(Blog blog)
		{
			await _DbContext.Blogs.AddAsync(blog);
			await _DbContext.SaveChangesAsync();
			return blog;
		}


		
		public async Task<int> UpdateAsync(int id, Blog blog)
		{
			return await _DbContext.Blogs
				  .Where(model => model.Id == id)
				  .ExecuteUpdateAsync(setters => setters
					.SetProperty(m => m.Name, blog.Name)
					.SetProperty(m => m.Description, blog.Description)
					.SetProperty(m => m.Author, blog.Author)
					.SetProperty(m => m.ImageUrl, blog.ImageUrl)
				  );
		}
		public async Task<int> DeleteAsync(int id)
		{
			return await _DbContext.Blogs
				  .Where(model => model.Id == id)
			.ExecuteDeleteAsync();
		}
	}
}
