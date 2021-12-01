using System;
using System.Data;
using System.Text;
using Task_2;

namespace Task_4
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //Task_4. Задание 1.1
      Console.WriteLine("Задание 1.1");
      MeetingType typeMeeting = MeetingType.Сonference;
      var startMeeting = DateTime.Now.AddMinutes(5);
      var endMeeting = DateTime.Now.AddMinutes(15);
      var meetWithType = new MeetWithTypeMeet(typeMeeting, startMeeting, endMeeting);
      Console.WriteLine(meetWithType.ToString());

      //Task_4. Задание 1.2
      Console.WriteLine("Задание 1.2");
      var startMeeting1 = DateTime.Now.AddMinutes(5);
      //DateTime endMeeting1 = DateTime.Now.AddMinutes(15); //для проверки подстановки нормального значения и значения null ниже
      DateTime? endMeeting1 = null;
      var meetWithoutEnd = new MeetWithoutEnd(startMeeting1, endMeeting1);
      Console.WriteLine(meetWithoutEnd.ToString());

      //Задание 2
      Console.WriteLine("Задание 2");
      Console.WriteLine(TableParser.Parse(DataSetWithDefalutValues.GetBookStore(), "|", ";"));

      //Задание 3
      Console.WriteLine("Задание 3");
      Console.WriteLine(AccessRightsService.GetAccessRightsInfo(AccessRights.Run | AccessRights.View | AccessRights.Edit)); 

      //Задание 4
      Console.WriteLine("Задание 4");
      DateTime now = DateTime.Now;
      Console.WriteLine("D: " + now.ToString("D"));
      Console.WriteLine("d: " + now.ToString("d"));
      Console.WriteLine("F: " + now.ToString("F"));
      Console.WriteLine("f: {0:f}", now);
      Console.WriteLine("G: {0:G}", now);
      Console.WriteLine("g: {0:g}", now);
      Console.WriteLine("M: {0:M}", now);
      Console.WriteLine("O: {0:O}", now);
      Console.WriteLine("o: {0:o}", now);
      Console.WriteLine("R: {0:R}", now);
      Console.WriteLine("s: {0:s}", now);
      Console.WriteLine("T: {0:T}", now);
      Console.WriteLine("t: {0:t}", now);
      Console.WriteLine("U: {0:U}", now);
      Console.WriteLine("u: {0:u}", now);
      Console.WriteLine("Y: {0:Y}", now);

      //Задание 5
      using var logger = new Logger("log.txt");
      logger.WriteString("Тестовый лог.");
    }
  }
}
