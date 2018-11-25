using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ConstructionCalculator.DataAccess
{
    public class File
    {
        [Key] public int Id { get; set; }

        [MaxLength(20)] public string FileName { get; set; }

        public FileType Type { get; set; }

        [MaxLength(200)] public string Description { get; set; }

        public static File Select(ConstructionDataContext context, string name, FileType type)
        {
            return context.Files.FirstOrDefault(f =>
                f.FileName.Equals(name, StringComparison.CurrentCultureIgnoreCase)
                && f.Type == type);
        }

        public int Add(ConstructionDataContext context)
        {
            context.Files.Add(this);
            context.SaveChanges();
            return Id;
        }

        //todo: create a abstract class 
        public void Update(ConstructionDataContext context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(ConstructionDataContext context)
        {
            context.Files.Remove(this);
            context.SaveChanges();
        }
    }

    public enum FileType
    {
        BusinessFeature,
        BusinessValue,
        CellMapping,
        ConstructionValue,
        RiskLevel,
        Construction
    }
}