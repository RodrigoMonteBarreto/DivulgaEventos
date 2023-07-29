using System.Collections;
using System.Collections.Generic;
using System;
namespace DivulgaEventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImagemURL { get; set; }
        public string Email { get; set; }
        public ICollection<Lote> Lotes { get; set; }
        public ICollection<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
        
    }
}