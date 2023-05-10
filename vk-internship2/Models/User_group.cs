using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vk_internship2.Models
{
    [Table("user_groups")]
    public class User_group
	{
        [Key, Required]
        public int id { get; set; }
		public string? code { get; set; }
		public string? description { get; set; }

		
		public User_group(string code)
		{
			if (code == "Admin")
			{
				this.code = "Admin";
				this.description = "Admin user";
			}
			else
			{
				this.code = "User";
				this.description = "A common user without any special rights";
			}
		}
	}
}

