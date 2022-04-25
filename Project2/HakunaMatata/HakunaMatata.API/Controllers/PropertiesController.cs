using AutoMapper;
using HakunaMatata.API.Dto;
using HakunaMatata.Application.Commands;
using HakunaMatata.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HakunaMatata.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PropertiesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            var query = new GetAllPropertiesQuery();

            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<PropertyGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var query = new GetPropertyByIdQuery
            {
                PropertyId = id
            };

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<PropertyGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(PropertyCreateDto newProperty)
        {
            if (newProperty == null)
                return BadRequest("New property can't be null");

            var command = new CreatePropertyCommand
            {
                Name = newProperty.Name,
                Description = newProperty.Description,
                Address = newProperty.Address,
                MaxGuests = newProperty.MaxGuests,
                Price = newProperty.Price
            };

            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<PropertyGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var command = new DeletePropertyCommand
            {
                PropertyId = id
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, PropertyCreateDto property)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            if (property == null)
                return BadRequest("Property can't be null");

            var command = new UpdatePropertyCommand
            {
                PropertyId = id,
                Name = property.Name,
                Description = property.Description,
                Address = property.Address,
                MaxGuests = property.MaxGuests,
                Price = property.Price
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<PropertyGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("{propertyId}/property/{imageId}")]
        public async Task<IActionResult> AddPropertyToUser(int propertyId, int imageId)
        {
            if (propertyId <= 0 || imageId <= 0)
                return BadRequest("Invalid ID");

            var command = new AddImageToPropertyCommand
            {
                PropertyId = propertyId,
                ImageId = imageId
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<PropertyGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
