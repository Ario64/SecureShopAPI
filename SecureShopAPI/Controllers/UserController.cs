using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecureShopAPI.DTOs.UserDto;
using SecureShopAPI.Models;
using SecureShopAPI.UnitOfWorkService;

namespace SecureShopAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                return NotFound("There is no user!");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newUser = _mapper.Map<User>(user);
            await _unitOfWork.UserRepository.AddUser(newUser);
            return CreatedAtAction("GetById", new { Id = newUser.Id }, newUser);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangePassword(int id, UpdateUserDto updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                return NotFound("There is no user!");
            }

            _mapper.Map(updatedUser, user);

            await _unitOfWork.UserRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                return NotFound("There is no fucking user!");
            }

            await _unitOfWork.UserRepository.DeleteUser(user);
            return NoContent();
        }
    }
}
