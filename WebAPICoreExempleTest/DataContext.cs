using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICoreExempleTest
{
    public class DataContext: DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        { }

        public DbSet<Models.GrupoOperacao> GrupoOperacao { get; set; } 
        public DbSet<Models.Operacao> Operacao { get; set; } 
        public DbSet<Models.Cliente> Cliente { get; set; } 
     }
}
