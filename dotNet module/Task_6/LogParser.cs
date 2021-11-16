using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_6
{
  /// <summary>
  /// Парсер текстовго файла.
  /// </summary>
  public class LogParser
  {
    /// <summary>
    /// Проверяет входит ли рассматриваемая дата в интервал дат.
    /// </summary>
    /// <param name="dateToCheck">Рассматриваемая дата.</param>
    /// <param name="startDate">Начальная дата интервала.</param>
    /// <param name="endDate">Конечная дата интервала.</param>
    /// <returns>Возвращает true, если dateToCheck входит в интервал дат.</returns>
    private static bool IsInRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
    {
      return dateToCheck >= startDate && dateToCheck < endDate;
    }

    /// <summary>
    /// Показывает записи совершенные в интервал дат.
    /// </summary>
    /// <param name="path">Путь к текстовому файлу.</param>
    /// <param name="beginInterval">Начальная дата интервала.</param>
    /// <param name="endInterval">Конечная дата интервала.</param>
    /// ///<remarks>Можно увидеть выходные записи, раскоментировав строку кода 52.</remarks>
    public static int LogParse(string path, DateTime beginInterval, DateTime endInterval)
    {
      int count = 0;
      try
      {
        using var reader = new StreamReader(path, System.Text.Encoding.Default);
        DateTime parseDateTime;
        string line;
        char separator = '\t';
        int indexOfSep;
        string parsedString;
        reader.ReadLine();
        while ((line = reader.ReadLine()) != null)
        {
          indexOfSep = line.IndexOf(separator);
          parsedString = line[..indexOfSep];
          if (DateTime.TryParse(parsedString, out parseDateTime))
            if (IsInRange(parseDateTime, beginInterval, endInterval))
            {
              //Console.WriteLine(line);
              count++;
            }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

      return count;
    }
  }
}
