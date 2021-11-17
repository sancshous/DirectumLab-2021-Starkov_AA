using System;
using System.IO;

namespace Task_6
{
  public class Program
  {
    static void Main(string[] args)
    {
      var beginInterval = new DateTime(2007, 12, 10, 12, 00, 00);
      var endInterval = new DateTime(2007, 12, 16, 12, 00, 00);
      Console.WriteLine("Количество записей: " + LogParser.LogParse("ClientConnectionLog.log", beginInterval, endInterval)); 
    }
  }
}
