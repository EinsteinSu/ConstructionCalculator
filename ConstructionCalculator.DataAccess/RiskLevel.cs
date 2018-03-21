using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.DataAccess
{
    public class RiskLevel
    {
        public int Id { get; set; }

        public double MinValue { get; set; }

        public double MaxValue { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }
    }
}
