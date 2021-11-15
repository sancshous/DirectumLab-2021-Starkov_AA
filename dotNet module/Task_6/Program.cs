using System;
using System.IO;

namespace Task_6
{
  public class Program
  {
    static void Main(string[] args)
    {
      string path = @"C:\Users\shura\Documents\GitHub\DirectumLab-2021-Starkov_AA\dotNet module\Task_6\log.txt";
      var beginInterval = new DateTime(2018, 03, 01, 12, 00, 00);
      var endInterval = new DateTime(2018, 04, 01, 12, 00, 00);
      LogParser.LogParse(path, beginInterval, endInterval);
    }
  }
}
