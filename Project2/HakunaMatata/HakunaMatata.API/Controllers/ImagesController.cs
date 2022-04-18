//using AutoMapper;
//using HakunaMatata.API.Dto;
//using HakunaMatata.Application.Commands;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace HakunaMatata.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//            private readonly IMediator _mediator;
//            private readonly IMapper _mapper;

//            public ImagesController(IMediator mediator, IMapper mapper)
//            {
//                _mediator = mediator;
//                _mapper = mapper;
//            }

//            [HttpPost]
//            public async Task<IActionResult> CreateImage(ImageCreateDto image)
//            {
//                var command = new CreateImageCommand
//                {
//                    Name = image.Name,
//                    Path = image.Path
//                };

//                var createdProperty = await _mediator.Send(command);
//                var mappedResult = _mapper.Map<ImageGetDto>(createdProperty);
//                return Ok(mappedResult);
//            }
//    }
//}
