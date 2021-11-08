using System;

namespace Task_2
{
  public class Program
  {
    public static void Main(string[] args)
    {
      DateTime startMeeting = DateTime.Now.AddHours(5);
      DateTime endMeeting = DateTime.Now.AddHours(8);
      var meeting = new Meeting(startMeeting, endMeeting);
      Console.WriteLine($"Начало встречи: {meeting.StartMeeting} \nОкончание встречи: {meeting.EndMeeting} \nПродолжительность встречи: {meeting.Duration}");

      var meetWithRemind = new MeetingWithRemind();
      var remind = DateTime.Now.AddSeconds(10);
      meetWithRemind.Remind = remind;
      meetWithRemind.SetTimer();
      Console.ReadKey();
      Console.WriteLine($"Твоя встреча начнется через {startMeeting.Subtract(remind)}");
    }
  }
}
