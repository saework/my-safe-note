using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySafeNote.Core;
using MySafeNote.DataAccess;

namespace my_safe_note.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    return _dataContext.Users.ToList();
        //}

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _dataContext.Users.ToListAsync();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // PUT api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User updatedUser)
        {
            // Имитация асинхронной операции.
            //await Task.Delay(10); 

            if (updatedUser is null)
            {
                return BadRequest("updatedUser пустой");
            }

            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound($"User с ID: {id} не найден.");
            }
            // Обновляем данные пользователя
            user.Email = updatedUser.Email;
            user.PasswordHash = updatedUser.PasswordHash;
            await _dataContext.SaveChangesAsync(); 

            return Ok(user);
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                return Ok(id);
            }
            else
                return NotFound($"User с ID: {id} не найден.");
        }
    }
}
