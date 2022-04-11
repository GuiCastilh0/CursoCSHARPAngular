using ProEventos.Application.Dtos;

namespace ProEventos.Application.DTOs
{
    public class RedeSocialDto
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public EventoDto Evento { get; set; }
        public int? PalestranteId { get; set; }
        public PalestranteDto Palestrante { get; set;}
    }
}