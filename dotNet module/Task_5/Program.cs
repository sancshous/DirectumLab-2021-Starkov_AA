using System;
using System.Collections;

namespace Task_5
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // Задание 1
      Console.WriteLine(new StringValue("AAA").Equals(new StringValue("AAA")));

      // Задание 2
      Console.WriteLine(new StringValue("AAA") == (new StringValue("AAA")));

      // Задание 3
      var twoComplexes = new ArrayList() 
      { 
        new Complex() { Re = 3, Im = 5 }, 
        new Complex() { Re = 2, Im = 2 } 
      };

      Console.WriteLine("Массив до сортировки: ");
      foreach (var complex in twoComplexes)
        Console.Write(complex);
      twoComplexes.Sort();
      Console.WriteLine("\nМассив после сортировки: ");
      foreach (var complex in twoComplexes)
        Console.Write(complex);
    }
  }
}
