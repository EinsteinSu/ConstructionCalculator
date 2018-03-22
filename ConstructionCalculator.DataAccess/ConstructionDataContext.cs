using System;
using System.Data.Entity;

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

        public DbSet<BusinessFeature> BusinessFeatures { get; set; }

        public DbSet<RiskLevel> RiskLevels { get; set; }
    }
}