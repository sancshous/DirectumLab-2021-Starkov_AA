using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_8;

namespace Task_9
{
  public class Program
  {
    /// <summary>
    /// Парсит запись из файла на дату и время.
    /// </summary>
    /// <param name="record">Запись из файла.</param>
    /// <returns>Возвращает дату и время типа DateTime.</returns>
    public static DateTime? DateTimeFromRecord(string record)
    {
      string[] substr = record.Split('\t');
      string parsedString = substr[0] + " " + substr[1];
      if (DateTime.TryParse(parsedString, out var parseDateTime))
        return parseDateTime;
      else
        return null;
    }

    /// <summary>
    /// Фильтрует строки лог-файла на указанную дату и сортирует их по времени. 
    /// </summary>
    /// <param name="file">Лог-файл.</param>
    /// <param name="date">Указанная дата.</param>
    /// <returns>Возвращает отсортированный список по убыванию времени за сутки.</returns>
    public static List<string> SortTimeOfDay(string file, DateTime date)
    {
      var line = new StreamReaderEnumerable(file);
      return line
        .Select(line => (line, dateTime: DateTimeFromRecord(line)))
        .Where(tuple => tuple.dateTime.HasValue && date.Date == tuple.dateTime.Value.Date)
        .OrderByDescending(tuple => tuple.dateTime.Value.TimeOfDay)
        .Select(tuple => tuple.line)
        .ToList();
    }

    static void Main(string[] args)
    {
      var date = new DateTime(2007, 12, 12);
      foreach (var line in SortTimeOfDay("ClientConnectionLog.log", date))
        Console.WriteLine(line);
    }
  }
}
