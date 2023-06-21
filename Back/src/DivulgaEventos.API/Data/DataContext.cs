using DivulgaEventos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DivulgaEventos.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }

    }
}