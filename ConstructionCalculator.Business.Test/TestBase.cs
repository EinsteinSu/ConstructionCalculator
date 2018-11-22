using System;
using System.IO;
using System.Reflection;
using ConstructionCalculator.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class TestBase
    {
        private const string Prefix = "ConstructionCalculator.Business.Test.TestResource.";
        protected ConstructionDataContext Context = new ConstructionDataContext("Construction");

        [TestCleanup]
        public virtual void Cleanup()
        {
            Context.Database.ExecuteSqlCommand("Delete From Constructions");
            Context.Database.ExecuteSqlCommand("Delete From BusinessFeatures");
            Context.Database.ExecuteSqlCommand("Delete From BusinessValues");
            Context.Database.ExecuteSqlCommand("Delete From ConstructionValues");
            Context.Database.ExecuteSqlCommand("Delete From CellMappings");
            Context.Database.ExecuteSqlCommand("Delete From RiskLevels");
            Context.Database.ExecuteSqlCommand("Delete From Files");
            Context.Dispose();
        }

        protected void ImportAndValidate(string fileName, Action<Stream> validation)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream =
                assembly.GetManifestResourceStream(Prefix + fileName)
            )
            {
                validation?.Invoke(stream);
            }
        }
    }
}