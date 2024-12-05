using Microsoft.EntityFrameworkCore;
using PrjProcesso.Models;
using System.Diagnostics;

namespace PrjProcesso.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Processo> Processos { get; set; }
    }
}