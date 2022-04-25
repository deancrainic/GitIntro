using AutoMapper;
using HakunaMatata.API.Dto;
using HakunaMatata.Application.Commands;
using HakunaMatata.Application.Queries;
using HakunaMatata.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HakunaMatata.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();

            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<List<UserGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var query = new GetUserByIdQuery { UserId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDto newUser)
        {
            if (newUser == null)
                return BadRequest("New user can't be null");

            var command = new CreateUserCommand
            {
                Email = newUser.Email,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
            };

            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var command = new DeleteUserCommand { UserId = id };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserCreateDto user)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            if (user == null)
                return BadRequest("User can't be null");

            var command = new UpdateUserCommand
            {
                UserId = id,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        } 

        [HttpPost]
        [Route("{userId}/property/{propertyId}")]
        public async Task<IActionResult> AddPropertyToUser(int userId, int propertyId)
        {
            if (userId <= 0 || propertyId <= 0)
                return BadRequest("Invalid ID");

            var command = new AddPropertyToUserCommand
            {
                UserId = userId,
                PropertyId = propertyId
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
