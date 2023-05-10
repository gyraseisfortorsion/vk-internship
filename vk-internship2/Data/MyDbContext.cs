using System;
using Microsoft.EntityFrameworkCore;
using vk_internship2.Models;

namespace vk_internship2.Data
{
	public class MyDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
        public DbSet<User_group> User_groups { get; set; }
        public DbSet<User_state> User_states { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{

		}
	}
}

