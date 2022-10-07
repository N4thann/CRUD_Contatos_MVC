using ContatosMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContatosMVC.Data
{
    public class NZContext : DbContext
    {

            public NZContext(DbContextOptions<NZContext> options) : base(options)
            {
            }

            public DbSet<ContatoModel> Contatos { get; set; }
    }
}
