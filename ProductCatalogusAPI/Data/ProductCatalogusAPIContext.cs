using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalogusAPI.Models;

namespace ProductCatalogusAPI.Data
{
    public class ProductCatalogusAPIContext : DbContext
    {
        public ProductCatalogusAPIContext (DbContextOptions<ProductCatalogusAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCatalogusAPI.Models.Potplant> Potplant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=tcp:shared-hosting.database.windows.net,1433;Initial Catalog=StageOpdrachtEva_db;Persist Security Info=False;User ID=Eva;Password=z9YubrA1x27rj4C3BpE1wMSU;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
