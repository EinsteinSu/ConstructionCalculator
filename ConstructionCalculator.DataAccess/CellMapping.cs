using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCalculator.DataAccess
{
    public class CellMapping
    {
        public int Id { get; set; }

        public File File { get; set; }

        [ForeignKey("File")]
        public int? FileId { get; set; }

        public int ColumnNumber { get; set; }

        [MaxLength(10)] public string ColumnExcelNumber { get; set; }

        [MaxLength(100)] public string ColumnName { get; set; }

        public CalculatGroup Group { get; set; }


        [MaxLength(500)] public string Formula { get; set; }

        public int Digital { get; set; }
    }

    public enum CalculatGroup
    {
        Normal,
        Result,
        ParameterT
    }
}