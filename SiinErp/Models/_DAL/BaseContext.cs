using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models._DAL
{
    public class BaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("SiinErpDbContext"), options => { });
        }

        #region General
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        public virtual DbSet<Errores> Errores { get; set; }
        #endregion
    }
}
