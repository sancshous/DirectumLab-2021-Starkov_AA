using NUnit.Framework;
using System;
using System.IO;
using Task_4;

namespace Task4_8Tests
{
  [TestFixture]
  public class Task4UnitTests
  {
    [Test]
    public void MeetWithoutEndTest()
    {
      var expected = TimeSpan.MaxValue;
      var startMeeting = DateTime.Now.AddMinutes(5);
      DateTime? endMeeting = null;
      var actual = new MeetWithoutEnd(startMeeting, endMeeting);
      Assert.AreEqual(expected, actual.Duration);
    }

    [Test]
    public void TableParserTest()
    {
      var expected = "1|����� � ���|200|40,0;2|���� � ����|170|34,0;";
      var actual = TableParser.Parse(DataSetWithDefalutValues.GetBookStore(), "|", ";");
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(AccessRights.AccessDenied, ExpectedResult = "������ ��������.")]
    [TestCase(AccessRights.Edit | AccessRights.Ratify, ExpectedResult = "� ��� ���� �����: Edit, Ratify")]
    [TestCase(AccessRights.AccessDenied | AccessRights.Ratify, ExpectedResult = "������ ��������.")]
    [TestCase(AccessRights.Add | AccessRights.Delete, ExpectedResult = "� ��� ���� �����: Add, Delete")]
    [TestCase(AccessRights.Run | AccessRights.View | AccessRights.Edit, ExpectedResult = "� ��� ���� �����: View, Run, Edit")]
    public string AccessRightsServiceTest(AccessRights accessRights)
    {
      return AccessRightsService.GetAccessRightsInfo(accessRights);
    }

    [Test]
    public void LoggerWriteStringTest()
    {
      var expected = "�������� ���.";
      using var logger = new Logger("log.txt");
      logger.WriteString("�������� ���.");
      logger.Dispose();
      string line;
      using (var sr = new StreamReader("log.txt", System.Text.Encoding.Default))
      {
        line = sr.ReadLine();
      }
      Assert.AreEqual(expected, line);
    }
  }
}