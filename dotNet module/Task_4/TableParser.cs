using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Task_4
{
  public class TableParser
  {
    public static string Parse(DataSet dataset, string rowSeparator, string columnSeparator)
    {
      var sb = new StringBuilder();

      foreach (DataRow row in dataset.Tables[0].Rows)
      {
        foreach (var cell in row.ItemArray)
        {
          if (cell.Equals(row.ItemArray[^1]))
          {
            sb.Append(cell);
            sb.Append(columnSeparator);
          }
          else
          {
            sb.Append(cell);
            sb.Append(rowSeparator);
          }
        }
      }
      string value = sb.ToString();
      return value;
    }
  }
}
