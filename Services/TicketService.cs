using AutoMapper;
using Concert.DbContexts;
using Concert.Dto;
using Concert.Entities;
using Concert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concert.Services
{
    public class TicketService : ITicketService
    {
        private readonly ConcertContext _context;
        private readonly IMapper _mapper;

        public TicketService(ConcertContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TicketDto> AddTicketAsync(TicketDto ticketDto)
        {
            if (ticketDto == null)
            {
                throw new ArgumentNullException(nameof(ticketDto));
            }
            var libroEntity = _mapper.Map<TicketEntity>(ticketDto);
            _context.Tickets.Add(libroEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TicketDto>(libroEntity);
        }

        public async Task<bool> DeleteTicketAsync(string id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return false;
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TicketDto> GetTicketByIdAsync(string id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<TicketDto>(ticket);
        }


        public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
        {
            var ticket = await _context.Tickets.ToListAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(ticket);
        }
    }
}
