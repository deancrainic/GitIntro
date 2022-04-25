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
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReservationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations() 
        {
            var query = new GetAllReservationsQuery();

            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<IEnumerable<ReservationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var query = new GetReservationByIdQuery
            {
                ReservationId = id
            };

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ReservationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationCreateDto newReservation)
        {
            if (newReservation == null)
                return BadRequest("New reservation can't be null");

            var command = new CreateReservationCommand
            {
                PropertyId = newReservation.PropertyId,
                CheckinDate = newReservation.CheckinDate,
                CheckoutDate = newReservation.CheckoutDate,
                GuestsNumber = newReservation.GuestsNumber,
                TotalPrice = newReservation.TotalPrice
            };

            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<ReservationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var command = new DeleteReservationCommand { ReservationId = id };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, ReservationCreateDto reservation)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            if (reservation == null)
                return BadRequest("Reservation can't be null");

            var command = new UpdateReservationCommand
            {
                ReservationId = id,
                PropertyId = reservation.PropertyId,
                CheckinDate = reservation.CheckinDate,
                CheckoutDate = reservation.CheckoutDate,
                GuestsNumber = reservation.GuestsNumber,
                TotalPrice = reservation.TotalPrice
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ReservationGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
