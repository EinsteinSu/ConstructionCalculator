using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.DataAccess
{
    public class CellMapping
    {
        public int Id { get; set; }

        public int ColumnNumber { get; set; }

        public string ColumnExcelNumber { get; set; }

        public string ColumnName { get; set; }
    }
}
