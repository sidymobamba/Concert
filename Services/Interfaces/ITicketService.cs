using Concert.Dto;

namespace Concert.Services.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTicketsAsync();
        Task<TicketDto> GetTicketByIdAsync(string id);
        //Task<TicketDto> GetCO2TicketByIdAsync(string id);
        Task<TicketDto> AddTicketAsync(TicketDto func);
        Task<bool> DeleteTicketAsync(string id);
    }
}
