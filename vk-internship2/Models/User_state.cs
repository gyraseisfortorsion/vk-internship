using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vk_internship2.Models
{
    [Table("user_states")]
    public class User_state
	{
        [Key, Required]
        public int id { get; set; }
        public string? code { get; set; }
        public string? description { get; set; }

        //public User_state(int id)
        //{
        //    if (id == 0)
        //    {
        //        this.code = "Blocked";
        //        this.description = "This user account is blocked";
        //    }
        //    else
        //    {
        //        this.code = "Active";
        //        this.description = "This user account is active";
        //    }
        //}
        public User_state()
        {
            this.code = "Active";
            this.description = "This user account is active"; 
        }
    }
}

