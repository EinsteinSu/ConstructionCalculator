using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConstructionCalculator.DataAccess.Interfaces;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Utilities
{
    public static class ExportHelper
    {
        public static void Export<T>(this IEnumerable<T> data, string filePath, string sheetName) where T : IExport
        {
            using (var excel = new ExcelPackage())
            {
                if (!data.Any())
                    return;
                //write header
                var sheet = excel.Workbook.Worksheets.Add(sheetName);
                var isStartRow = true;
                var row = 2;

                foreach (var item in data)
                {
                    if (isStartRow)
                    {
                        var header = item.GetHeader();
                        sheet.WriteHeader(header);
                        isStartRow = false;
                    }

                    sheet.WriteRow(item.GetRow(), row);
                    row++;
                }

                excel.SaveAs(new FileInfo(filePath));
            }
        }
    }
}