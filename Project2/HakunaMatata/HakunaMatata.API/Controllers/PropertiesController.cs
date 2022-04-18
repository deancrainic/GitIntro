//using AutoMapper;
//using HakunaMatata.API.Dto;
//using HakunaMatata.Application.Commands;
//using HakunaMatata.Application.Queries;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HakunaMatata.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PropertiesController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        private readonly IMapper _mapper;

//        public PropertiesController(IMediator mediator, IMapper mapper)
//        {
//            _mediator = mediator;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllProperties()
//        {
//            var query = new GetAllPropertiesQuery();
//            var result = await _mediator.Send(query);
//            var mappedResult = _mapper.Map<List<PropertyGetDto>>(result);

//            return Ok(mappedResult);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateProperty(PropertyCreateDto property)
//        {
//            var command = new CreatePropertyCommand
//            {
//                Name = property.Name,
//                Description = property.Description,
//                Address = property.Address,
//                MaxGuests = property.MaxGuests,
//                Price = property.Price
//            };

//            var createdProperty = await _mediator.Send(command);
//            var mappedResult = _mapper.Map<PropertyGetDto>(createdProperty);
//            return Ok(mappedResult);
//        }

//        [HttpPost]
//        [Route("{propertyId}/images/{imageId}")]
//        public async Task<IActionResult> AddImageToProperty(int propertyId, int imageId)
//        {
//            var command = new AddImageToPropertyCommand
//            {
//                PropertyId = propertyId,
//                ImageId = imageId
//            };

//            var result = await _mediator.Send(command);
//            var mappedResult = _mapper.Map<PropertyGetDto>(result);

//            return Ok(mappedResult);
//        }
//    }
//}
