using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Panificadora.Models;

namespace API_Panificadora.Data
{
    public class API_PanificadoraContext : DbContext
    {
        public API_PanificadoraContext (DbContextOptions<API_PanificadoraContext> options)
            : base(options)
        {
        }

        public DbSet<API_Panificadora.Models.ClienteModelView> ClienteModelView { get; set; } = default!;
    }
}
