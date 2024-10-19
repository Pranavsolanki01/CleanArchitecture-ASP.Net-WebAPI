using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

		public DbSet<Blog> Blogs { get; set; }
	}
}
