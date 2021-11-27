using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPagos.Models;

namespace ApiPagos.Data
{
    public class ApiPagosContext : DbContext
    {

        public ApiPagosContext (DbContextOptions<ApiPagosContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPagos.Models.pagos> pagos { get; set; }
        public DbSet<ApiPagos.Models.pedidos> pedidos { get; set; }
    }
}
