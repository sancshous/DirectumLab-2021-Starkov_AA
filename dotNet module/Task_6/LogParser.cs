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
    public static bool IsInRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
    {
      return dateToCheck >= startDate && dateToCheck < endDate;
    }

    /// <summary>
    /// Показывает записи совершенные в интервал дат.
    /// </summary>
    /// <param name="path">Путь к текстовому файлу.</param>
    /// <param name="beginInterval">Начальная дата интервала.</param>
    /// <param name="endInterval">Конечная дата интервала.</param>
    public static void LogParse (string path, DateTime beginInterval, DateTime endInterval)
    {
      try
      {
        using var sr = new StreamReader(path, System.Text.Encoding.Default);
        string line;
        char separator = '-';
        int indexOfSep;
        string parsedString;
        while ((line = sr.ReadLine()) != null)
        {
          indexOfSep = line.IndexOf(separator);
          parsedString = line[..indexOfSep];
          if (IsInRange(DateTime.Parse(parsedString), beginInterval, endInterval))
            Console.WriteLine(line);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}
