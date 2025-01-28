using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;


namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new();

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var users = Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                {
                    return BadRequest("Name is required.");
                }
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    return BadRequest("Email is required.");
                }
                if (!Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return BadRequest("Invalid email format.");
                }

                user.Id = Users.Count + 1;
                Users.Add(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                var existingUser = Users.FirstOrDefault(u => u.Id == id);
                if (existingUser == null)
                {
                    return NotFound("User not found.");
                }

                if (string.IsNullOrWhiteSpace(user.Name))
                {
                    return BadRequest("Name is required.");
                }

                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    return BadRequest("Email is required.");
                }

                if (!Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return BadRequest("Invalid email format.");
                }

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                return NoContent();
            }
            catch (JsonException ex)
            {
                return BadRequest($"Error deserializing JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                Users.Remove(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
