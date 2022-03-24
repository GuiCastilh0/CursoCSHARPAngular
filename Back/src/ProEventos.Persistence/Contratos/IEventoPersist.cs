using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        //Eventos          
        Task<Evento[]> GetAllEventosByTemaAsync (string tema ,  bool includesPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync (bool includesPalestrantes = false);
        Task<Evento> GetEventoByIdAsync (int EventoId ,  bool includesPalestrantes = false);
    }
}