using System;
using Microsoft.AspNetCore.Mvc;
using DivulgaEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace DivulgaEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private Evento[] _eventos = {new Evento{
                    EventoId = 1,
                    Local = "Sergipe",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                    Tema = "DotNet  e sua novidades",
                    ImagemURL = "foto.png"
                },

                new Evento{
                    EventoId = 2,
                    Local = "São Paulo",
                    Lote = "2º Lote",
                    QtdPessoas = 450,
                    DataEvento = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy"),
                    Tema = "C# 11",
                    ImagemURL = "foto.png"
                }};
        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _eventos.SingleOrDefault(x => x.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Inserindo";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "Alterando";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Deletando";
        }
    }
}
