using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business
{
    public class ConstructionFormula
    {
        public CalculatGroup Group { get; set; }

        public int ColumnId { get; set; }

        //how to convert string to formula with google
        public string Formula { get; set; }

        public double GetResult(ExcelWorksheet sheet, CellMapping mapping, Construction construction)
        {
            //write data to excel
            //add a column with columnid from mapping
            //calc formula with mapping excel header
            return 0;
        }
    }

    public enum CalculatGroup
    {
        潜在风险, 接受水准, 防火水准, 火灾风险
    }
}
