using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.DataAccess
{
    public class ConstructionDataContext : DbContext
    {
        public ConstructionDataContext() : base("Constraction")
        {

        }

        public DbSet<CellMapping> CellMappings { get; set; }

        public DbSet<Construction> Constructions { get; set; }

        public DbSet<ConstructionValue> ConstructionValues { get; set; }

        public DbSet<BusinessValue> BusinessValues { get; set; }
    }
}
