using System;
using System.Collections.Generic;

namespace Task_10
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Predicate<int> isPositive = x => x > 0;
      Predicate<int> isEven = x => (x % 2) == 0;
      var list = new List<int> { 1, 5, -8, 10, -3, -6, 4, 20, 21, -46, 50, -63 };
      var fastSearcher = new FastSearcher();

      foreach (var cell in fastSearcher.SearchValues<int>(list, isEven))
        Console.WriteLine(cell + " ");
    }
  }
}
