using GutenbergBookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GutenbergBookshelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GutenbergDbContext _context;

        public UsersController(GutenbergDbContext context)
        {
            _context = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }


        // GET api/<UsersController>/5/books
        [HttpGet("{id}/books")]
        public async Task<ActionResult<User>> GetUsersWithBooks(int id)
        {
            var users = await _context.Users.FindAsync(id);

            var Usersbooks = await _context.Books.Where(w => w.UserId == users.Id).ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            if(Usersbooks == null)
            {
                return null;
            }

            return Ok(Usersbooks);
        }










        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User user)
        {
            user.RegisterDate = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostUsers", new { id = user.Id }, user);
        }


        // PUT api/<UsersController>/5
        public async Task<IActionResult> PutUsers(int id, User users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
