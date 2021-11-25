using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Task_13
{
  public static class EarlyBindExcelApp
  {
    public static void MultiplyTable()
    {
      var excelApp = new Excel.Application();
      excelApp.Visible = true;
      var workBook = excelApp.Workbooks.Add(Type.Missing);
      excelApp.DisplayAlerts = false;
      var sheet = (Excel.Worksheet)excelApp.Worksheets[1];
      sheet.Name = "Таблица умножения";
      for (int i = 1; i <= 10; i++)
      {
        for (int j = 1; j <= 10; j++)
          sheet.Cells[i, j] = i * j;
      }

      Excel.Range range1 = sheet.Range[sheet.Cells[1, 1], sheet.Cells[10, 1]];
      Excel.Range range2 = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 10]];
      range1.Font.FontStyle = "Bold";
      range2.Font.FontStyle = "Bold";

      Excel.Range range3 = sheet.Range[sheet.Cells[1, 1], sheet.Cells[10, 10]];
      range3.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
      range3.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
      range3.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous;
      range3.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous;
      range3.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;

      range3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
      range3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

      excelApp.Application.ActiveWorkbook.SaveAs(
      "EarlyBind.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
      Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    }
  }
}
