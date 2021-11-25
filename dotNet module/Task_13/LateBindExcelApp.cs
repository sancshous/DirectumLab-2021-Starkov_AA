using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_13
{
  public class LateBindExcelApp
  {
    public static void MultiplyTable() 
    {
      string sAppProgID = "Excel.Application";

      dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID(sAppProgID));
      excelApp.Visible = true;
      excelApp.DisplayAlerts = false;

      var workBook = excelApp.Workbooks.Add(Type.Missing);
      var sheet = excelApp.Worksheets[1];
      sheet.Name = "Таблица умножения";

      for (int i = 1; i <= 10; i++)
      {
        for (int j = 1; j <= 10; j++)
          sheet.Cells[i, j] = i * j;
      }

      excelApp.Application.ActiveWorkbook.SaveAs(
      "LateBind.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

      Marshal.ReleaseComObject(excelApp); // Уничтожение объекта Excel
      GC.GetTotalMemory(true);   // Вызываем сборщик мусора для немедленной очистки памяти
    }
  }
}
