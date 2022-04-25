using AutoMapper;
using HakunaMatata.API.Dto;
using HakunaMatata.Application.Commands;
using HakunaMatata.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HakunaMatata.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ImagesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var query = new GetAllImagesQuery();

            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<ImageGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var query = new GetImageByIdQuery
            {
                ImageId = id
            };

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ImageGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(ImageCreateDto newImage)
        {
            if (newImage == null)
                return BadRequest("New image can't be null");

            var command = new CreateImageCommand
            {
                Name = newImage.Name,
                Path = newImage.Path
            };

            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<ImageGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var command = new DeleteImageCommand
            {
                ImageId = id
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok();
        }
    }
}
