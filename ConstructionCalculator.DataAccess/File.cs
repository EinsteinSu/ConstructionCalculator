using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.DataAccess
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string FileName { get; set; }

        public FileType Type { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }

    public enum FileType
    {
        BusinessFeature, BusinessValue, CellMapping, ConstructionValue, RiskLevel, Construction
    }
}
