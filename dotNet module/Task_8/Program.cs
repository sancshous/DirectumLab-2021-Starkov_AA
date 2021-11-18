using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_8
{
  public class Program
  {
    /// <summary>
    /// Перебор и вывод элементов колекции.
    /// </summary>
    /// <param name="collection">Коллекция.</param>
    public static void Show(IEnumerable collection)
    {
      foreach (var element in collection)
        Console.WriteLine(element);
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
      // Task 8.2
      Console.WriteLine("Task_8.2");
      int intValue1 = 2;
      int intValue2 = 10;
      int intValue3 = -1;
      Console.WriteLine(ComparableUtils<int>.MaxValue(intValue1, intValue2, intValue3));
      string stringValue1 = "abcd";
      string stringValue2 = "world";
      string stringValue3 = "hello";
      Console.WriteLine($"{ComparableUtils<string>.MaxValue(stringValue1, stringValue2, stringValue3)}\n");

      // Task 8.3
      Console.WriteLine("Task_8.3");
      var dictionary = new Dictionary<int, string>();
      dictionary.Add(1, "word1");
      dictionary.Add(2, "word2");
      dictionary.Add(3, "word3");
      dictionary.Add(4, "word4");
      dictionary.Add(5, "word5");
      dictionary.Add(6, "word6");
      Console.WriteLine("dictionary");
      Show(dictionary);
      var list = new List<string>();
      list.Add("letter1");
      list.Add("letter2");
      list.Add("letter3");
      list.Add("letter4");
      list.Add("letter5");
      Console.WriteLine("list");
      Show(list);

      // Task 8.4
      Console.WriteLine("Task_8.4");
      foreach (var line in new StreamReaderEnumerable("ClientConnectionLog.log"))
        Console.WriteLine(line);
    }
  }
}
