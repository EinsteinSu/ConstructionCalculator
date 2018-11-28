using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConstructionCalculator.DataAccess.Interfaces;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Utilities
{
    public static class ExportHelper
    {
        public static void Export<T>(this IEnumerable<T> data, string filePath, string sheetName, ILogPrint print = null, IShowProgress showProgress = null) where T : IExport
        {
            using (var excel = new ExcelPackage())
            {
                if (!data.Any())
                    return;
                //write header
                var sheet = excel.Workbook.Worksheets.Add(sheetName);
                var isStartRow = true;
                var row = 2;
                print?.PrintLog("Start writing entries to excel");
                showProgress?.SetMaxValue(data.Count());
                foreach (var item in data)
                {
                    if (isStartRow)
                    {
                        print?.PrintLog("Writing header");
                        var header = item.GetHeader();
                        sheet.WriteHeader(header);
                        isStartRow = false;
                    }
                    print?.PrintLog($"Writing row:{row}");
                    sheet.WriteRow(item.GetRow(), row);
                    showProgress?.SetCurrentValue(row - 1);
                    row++;
                }
                showProgress?.Done();
                print?.PrintLog("Saving file");
                excel.SaveAs(new FileInfo(filePath));
                print?.PrintLog($"Exported excel to {filePath}");
            }
        }
    }
}