using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos (Evento model);
        Task<Evento> UpdateEvento (int EventoId,Evento model );
        Task<bool> DeleteEvento (int eventoId);
        Task<Evento> GetEventoByIdAsync (int EventoId , bool includesPalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync (string tema ,  bool includesPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync (bool includePalestrantes = false);
    }
}