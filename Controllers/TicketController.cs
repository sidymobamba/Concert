using AutoMapper;
using Concert.DbContexts;
using Concert.Dto;
using Concert.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concert.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;
        private readonly ConcertContext _concertDb;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ITicketService ticketService, IMapper mapper, ConcertContext concertInfo, ILogger<TicketController> logger)
        {
            _ticketService = ticketService;
            _mapper = mapper;
            _concertDb = concertInfo;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        [HttpGet]
        public async Task<IActionResult> GetTicketsAsync()
        {
            var tickets = await _ticketService.GetTicketsAsync();
            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);
            return Ok(ticketsDto);
        }

        [HttpGet("TheWinnerIs")]
        public async Task<ActionResult<int>> GetWinner()
        {
            var WinnerId = await _concertDb.Tickets.Select(e => e.Id).ToListAsync();
            if (WinnerId.Count == 0)
            {
                return NotFound("Id not fuond");
            }

            var random = new Random();
            var randomWinnerId = WinnerId[random.Next(WinnerId.Count)];

            return Ok(randomWinnerId);
        }

        [HttpGet("total-CO2")]
        public async Task<ActionResult<decimal>> GetTotalPrice()
        {
            var totalCO2 = await _concertDb.Tickets.SumAsync(t => t.CO2);
            return Ok(totalCO2);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(string id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return Ok(ticketDto);
        }
        [HttpGet("CO2/{id}")]
        public async Task<IActionResult> GetCO2TicketById(string id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }
            var CO2 = ticket.CO2;
            return Ok(CO2);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] TicketDto ticket)
        {
            var newticket = await _ticketService.AddTicketAsync(ticket);
            return CreatedAtAction(nameof(GetTicketById), new { Id = newticket.CO2 }, newticket);
        }
    }
}
