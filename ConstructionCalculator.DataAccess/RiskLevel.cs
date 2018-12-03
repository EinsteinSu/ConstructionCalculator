using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess
{
    public class RiskLevel : IFile, IExport, IKey
    {
        public int Id { get; set; }

        [Display(Name = "最小值")]
        public double MinValue { get; set; }

        [Display(Name = "最大值")]
        public double MaxValue { get; set; }

        [Display(Name = "颜色")]
        [MaxLength(20)]
        public string Color { get; set; }

        [Display(Name = "说明")]
        public string Description { get; set; }

        public File File { get; set; }

        [ForeignKey("File")]
        public int? FileId { get; set; }
        public List<string> GetHeader()
        {
            return new List<string> { "最小值", "最大值", "颜色", "说明" };
        }

        public List<object> GetRow()
        {
            return new List<object> { MinValue, MaxValue, Color, Description };
        }

    }
}