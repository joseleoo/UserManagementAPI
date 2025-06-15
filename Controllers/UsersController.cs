using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // This is a placeholder for your user data store.
        private static readonly List<User> Users = new List<User>();

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(Users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            user.Id = Users.Count + 1; // Simple ID generation for demo
            Users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
                return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            // Update other fields as needed

            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
                return NotFound();

            Users.Remove(user);
            return NoContent();
        }
    }

    // Simple User model for demonstration
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Add other properties as needed
    }
}