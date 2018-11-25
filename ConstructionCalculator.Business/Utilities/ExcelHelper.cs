using System;
using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ConstructionCalculator.Business.Utilities
{
    public static class ExcelHelper
    {
        public static void WriteHeader(this ExcelWorksheet sheet, List<string> header, int startRow = 1)
        {
            var column = 1;
            foreach (var h in header)
            {
                var cell = sheet.Cells[startRow, column];
                cell.Value = h;
                column++;
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }
        }

        public static void WriteRow(this ExcelWorksheet sheet, List<object> rows, int rowIndex,
            Action<ExcelRange> write = null)
        {
            var column = 1;
            foreach (var r in rows)
            {
                var cell = sheet.Cells[rowIndex, column];
                cell.Value = r;
                write?.Invoke(cell);
                column++;
            }
        }
    }
}