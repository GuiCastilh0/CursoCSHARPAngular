using System.Threading.Tasks;
using ProEventos.Application.Dtos;
using ProEventos.Application.DTOs;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> AddEventos (EventoDto model);
        Task<EventoDto> UpdateEvento (int EventoId,EventoDto model );
        Task<bool> DeleteEvento (int eventoId);
        Task<EventoDto> GetEventoByIdAsync (int EventoId , bool includesPalestrantes = false);
        Task<EventoDto[]> GetAllEventosByTemaAsync (string tema ,  bool includesPalestrantes = false);
        Task<EventoDto[]> GetAllEventosAsync (bool includePalestrantes = false);
    }
}