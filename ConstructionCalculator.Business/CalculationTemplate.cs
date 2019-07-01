using System.Collections.Generic;

namespace ConstructionCalculator.Business
{
    public class CalculationTemplate
    {
        public Table BusinessFeature { get; set; }

        public Table ConstructionValue { get; set; }

        public Table RiskLevel { get; set; }

        public Table CellMapping { get; set; }

        public List<Table> Constructions { get; set; }

        
    }

    public class Table
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public static class TableHelper
    {
        public static string ToListString(this List<Table> tables)
        {
            string result = string.Empty;
            foreach (var table in tables)
            {
                result += $"{table.Name}, ";
            }

            return result.Trim().TrimEnd(',');
        }
    }
}