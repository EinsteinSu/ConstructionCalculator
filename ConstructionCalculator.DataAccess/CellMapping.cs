using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess
{
    public class CellMapping : IFile, IExport
    {
        public int Id { get; set; }

        public File File { get; set; }

        [Display(Name = "列序号")] public int ColumnNumber { get; set; }

        [Display(Name = "Excel列序号")]
        [MaxLength(10)]
        public string ColumnExcelNumber { get; set; }

        [Display(Name = "列名称")]
        [MaxLength(100)]
        public string ColumnName { get; set; }

        [Display(Name = "分类")] public CalculatGroup Group { get; set; }

        [Display(Name = "公式")]
        [MaxLength(500)]
        public string Formula { get; set; }

        [Display(Name = "小数位数")] public int Digital { get; set; }

        public List<string> GetHeader()
        {
            return new List<string> {"列序号", "Excel列序号", "列名称", "分类", "公式", "小数位数"};
        }

        public List<object> GetRow()
        {
            return new List<object> {ColumnNumber, ColumnExcelNumber, ColumnName, (int) Group, Formula, Digital};
        }

        [ForeignKey("File")] public int? FileId { get; set; }
    }

    public enum CalculatGroup
    {
        Normal,
        Result,
        ParameterT
    }
}