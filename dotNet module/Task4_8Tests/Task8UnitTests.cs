using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Task_8;

namespace Task_15
{
  [TestFixture]
  public class Task8UnitTests
  {
    [Test]
    [TestCase(2, 10, -1, ExpectedResult = 10)]
    [TestCase(null, 10, 2, ExpectedResult = 10)]
    [TestCase("abcd", "world", "hello", ExpectedResult = "world")]
    [TestCase("abcd", null, "hello", ExpectedResult = "hello")]
    public T ComparableUtilsMaxValueTest<T>(T Value1, T Value2, T Value3) where T : IComparable
    {
      return ComparableUtils<T>.MaxValue(Value1, Value2, Value3);
    }

    [Test]
    public void FileReaderTest()
    {
      string fileName = "ClientConnectionLog.log";
      string expectedLine;
      var expectedList = new List<string>();
      using (var streamReader = new StreamReader(fileName, System.Text.Encoding.Default))
      {
        while ((expectedLine = streamReader.ReadLine()) != null)
        {
          expectedList.Add(expectedLine);
        }
      }
      var list = new List<string>();
      foreach (var lineFromClass in new FileReader(fileName))
        list.Add(lineFromClass);
      Assert.AreEqual(expectedList, list);
    }
  }
}
