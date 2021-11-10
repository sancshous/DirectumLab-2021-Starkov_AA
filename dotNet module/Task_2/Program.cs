using System;

namespace Task_2
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //Task_2
      /*
      DateTime startMeeting = DateTime.Now.AddHours(5);
      DateTime endMeeting = DateTime.Now.AddHours(8);
      var meeting = new Meeting(startMeeting, endMeeting);
      Console.WriteLine($"Начало встречи: {meeting.StartMeeting} \nОкончание встречи: {meeting.EndMeeting} \nПродолжительность встречи: {meeting.Duration}");

      var meetWithRemind = new MeetingWithRemind();
      var remind = DateTime.Now.AddSeconds(10);
      meetWithRemind.Remind = remind;
      meetWithRemind.SetTimer();
      Console.ReadKey();
      */

      //Task_4. Задание 1.1
      Console.WriteLine("Задание 1.1");
      Console.Write("Введите тип встречи: ");
      string? typeMeeting = Console.ReadLine();
      DateTime startMeeting = DateTime.Now.AddMinutes(5);
      DateTime endMeeting = DateTime.Now.AddMinutes(15);
      var meetWithType = new MeetWithTypeMeet(typeMeeting, startMeeting, endMeeting);
      Console.WriteLine(meetWithType.ToString());


      //Task_4. Задание 1.2
      Console.WriteLine("Задание 1.2");
      DateTime startMeeting1 = DateTime.Now.AddMinutes(5);
      //DateTime endMeeting1 = DateTime.Now.AddMinutes(15); //для проверки подстановки нормального значения и значения null ниже
      DateTime? endMeeting1 = null;
      var meetWithoutEnd = new MeetWithoutEnd(startMeeting1, endMeeting1);
      Console.WriteLine(meetWithoutEnd.ToString());
    }
  }
}
