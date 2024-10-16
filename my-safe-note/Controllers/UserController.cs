using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySafeNote.Core;
using MySafeNote.Core.Abstractions;
using MySafeNote.DataAccess;
using MySafeNote.WebHost.Model;

namespace my_safe_note.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _dataContext;

        //public UserController(DataContext dataContext)
        //{
        //    _dataContext = dataContext;
        //}

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        //[HttpGet]
        //public async Task<IEnumerable<User>> GetUsersAsync()
        //{
        //    return await _dataContext.Users.ToListAsync();
        //}

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            //var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            var user = await _userRepository.GetByIdAsync(id);
            return Ok(user);
        }

        //[HttpPost("createuser")]
        [HttpPost]
        public async Task<ActionResult<int>> CreateUserAsync([FromBody] UserRequest userDto)
        {
            // Проверяем, что данные в данные валидны
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password))
            {
                return BadRequest("Некорректные данные.");
            }
            //var userExists = await _dataContext.Users.AnyAsync(x => x.Email == userDto.Email.Trim());
            var userExists = _userRepository.CheckUserExists(userDto.Email.Trim());
            if (userExists.Result)
            {
                return NotFound($"User с Email: {userDto.Email} уже создан.");
            }
            try
            {
                var passwordHash = Services.HashPassword(userDto.Password);
                var newUser = new User { Email = userDto.Email, PasswordHash = passwordHash };
                //_dataContext.Users.Add(newUser);
                //_dataContext.SaveChanges();
                var newUserId = await _userRepository.CreateAsync(newUser);
                return Ok(newUserId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера. {ex.Message}");
            }
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // PUT api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> ChangeUserByIdAsync(int id, [FromBody] UserRequest changedUser)
        {
            // Имитация асинхронной операции.
            //await Task.Delay(10); 

            if (changedUser is null)
            {
                return BadRequest("updatedUser пустой");
            }

            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return BadRequest($"User с ID: {id} не найден.");
            }
            // Обновляем данные пользователя
            user.Email = changedUser.Email;
            var passwordHash = Services.HashPassword(changedUser.Password);
            user.PasswordHash = passwordHash;
            await _dataContext.SaveChangesAsync(); 

            return Ok(user);
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteUserByIdAsync(int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();
                return Ok(id);
            }
            else
                return NotFound($"User с ID: {id} не найден.");
        }
    }
}
