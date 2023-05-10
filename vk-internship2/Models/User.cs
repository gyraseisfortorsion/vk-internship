using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vk_internship2.Models


{
    [Table("user")]
    public class User
	{
        [Key, Required]
        public int id { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public DateTime created_date { get; set; }


        public User_group? user_group_id { get; set; }

        
        public User_state? user_state_id { get; set; }

       
	}
}

