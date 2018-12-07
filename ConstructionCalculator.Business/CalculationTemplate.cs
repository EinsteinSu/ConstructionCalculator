using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.Business
{
    public class CalculationTemplate
    {
        public Table BusinessFeature { get; set; }

        public Table ConstructionValue { get; set; }

        public Table RiskLevel { get; set; }

        public Table CellMapping { get; set; }
    }

    public class Table
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
