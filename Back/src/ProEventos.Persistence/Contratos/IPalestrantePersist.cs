using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        // Palestrantes

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync (string tema , bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync (string tema , bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync (int EventoId , bool includeEvento);
        

    }
}