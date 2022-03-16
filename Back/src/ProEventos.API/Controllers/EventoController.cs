using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento [] {
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular 11 e .NET 5",
                    Local = "SP",
                    Lote = "1 lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemURL = "jorge"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Angular 34",
                    Local = "SP",
                    Lote = "1 lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemURL = "jorge2"
                }
            };
        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {  
            return _evento;
        }

        [HttpGet ("{id}")]
        public IEnumerable<Evento> Get(int id)
        {  
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {  
            return "Jorge";
        }

        [HttpPut("{id}")]

        public string Put(string id){
            return $"exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]

        public string Delete(string id){
            return $"exemplo de Delete com id = {id}";
        }
    }
}
