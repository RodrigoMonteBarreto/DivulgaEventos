using System;
using Microsoft.AspNetCore.Mvc;
using DivulgaEventos.API.Models;
using System.Collections.Generic;
using System.Linq;
using DivulgaEventos.API.Data;
using System.Threading.Tasks;

namespace DivulgaEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.SingleOrDefault(x => x.EventoId == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evento evento)
        {
            var retorno = _context.Eventos.SingleOrDefault(x => x.EventoId == evento.EventoId);
            if (retorno == null)
            {
                _context.Eventos.Add(evento);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "Alterando";
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var retorno = _context.Eventos.SingleOrDefault(x => x.EventoId == id);
            if (retorno == null)
            {
                return BadRequest();

            }
            _context.Eventos.Remove(retorno);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
