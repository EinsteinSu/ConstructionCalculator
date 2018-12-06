using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess
{
    public class File : IKey
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

        public bool Exists(ConstructionDataContext context)
        {
            return context.Files.Any(a => a.FileName == FileName);
        }

        //todo: create a abstract class 
        public void Update(ConstructionDataContext context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(ConstructionDataContext context)
        {
            var item = context.Files.FirstOrDefault(f => f.Id == Id);
            if (item != null)
            {
                #region remove related entries
                foreach (var c in context.CellMappings.Where(w => w.FileId == item.Id))
                {
                    context.CellMappings.Remove(c);
                }
                foreach (var c in context.BusinessFeatures.Where(w => w.FileId == item.Id))
                {
                    context.BusinessFeatures.Remove(c);
                }
                foreach (var c in context.BusinessValues.Where(w => w.FileId == item.Id))
                {
                    context.BusinessValues.Remove(c);
                }
                foreach (var c in context.Constructions.Where(w => w.FileId == item.Id))
                {
                    context.Constructions.Remove(c);
                }
                foreach (var c in context.ConstructionValues.Where(w => w.FileId == item.Id))
                {
                    context.ConstructionValues.Remove(c);
                }
                foreach (var c in context.RiskLevels.Where(w => w.FileId == item.Id))
                {
                    context.RiskLevels.Remove(c);
                }
                #endregion

                context.Files.Remove(item);
                context.SaveChanges();
            }

        }
    }

    public enum FileType
    {
        BusinessValue,
        BusinessFeature,
        ConstructionValue,
        RiskLevel,
        CellMapping,
        Construction
    }
}