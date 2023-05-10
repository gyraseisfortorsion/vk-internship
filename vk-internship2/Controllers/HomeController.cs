using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vk_internship2.Data;
using vk_internship2.Models;

namespace vk_internship2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            //var users = _context.Users.ToList();

            var users = await _context.Users.Include(u => u.user_group_id)
                                         .Include(u => u.user_state_id)
                                         .ToListAsync();
            
            return Ok(users);
            //return CreatedAtAction(nameof(GetU), new { id = user.id }, user);
        }

       
        [HttpGet("{id}")]
  
        public async Task<ActionResult<User>> GetUser(int id)
        {
            //var user = await _context.Users.FirstOrDefaultAsync(u => u.id == id);

            var user = await _context.Users.Include(u => u.user_group_id)
                                       .Include(u => u.user_state_id)
                                       .FirstOrDefaultAsync(u => u.id == id);


            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

       
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user, string user_group_code="User")

        {
            if (user_group_code!="User" && user_group_code != "Admin")
            {
                return BadRequest("No such user group");
            }
            if (user == null)
            {
                return BadRequest("Invalid payload");
            }

            if (string.IsNullOrEmpty(user.login) || string.IsNullOrEmpty(user.password))
            {
                return BadRequest("Login and password are required");
            }

            if (await _context.Users.AnyAsync(u => u.login == user.login))
            {
                return Conflict("User with the same login already exists");
            }

            

            var adminUsers = _context.User_groups.Where(u => u.code=="Admin").ToList();
            if (adminUsers.Count > 0 && user_group_code=="Admin")
            {
                return Conflict("There can only be one admin user");
            }


            User_group user_group = new User_group(user_group_code);
            User_state user_state = new User_state();
            user_state.code = "Active";

            user.user_group_id = user_group;
            user.user_state_id = user_state;
            

            _context.Users.Add(user);
            //_context.User_groups.Add(user_group);
            //_context.User_states.Add(user_state);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.id }, user);
        }

        //// PUT: api/user/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(int id, User user)
        //{
        //    if (id != user.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

      
        [HttpDelete("{id}")]
      
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User_states.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.id = 0;
            _context.Entry(user).Property(u => u.id).IsModified = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [NonAction]
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
