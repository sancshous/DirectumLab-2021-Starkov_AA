using System;

namespace Task_2
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var startMeeting = DateTime.Now.AddHours(5);
      var endMeeting = DateTime.Now.AddHours(8);
      var meeting = new Meeting(startMeeting, endMeeting);
      Console.WriteLine(meeting.ToString());

      var meetWithRemind = new MeetingWithRemind(startMeeting, endMeeting);
      var remind = DateTime.Now.AddSeconds(10);
      meetWithRemind.Remind = remind;
      meetWithRemind.SetTimer();
      Console.ReadKey();
    }
  }
}
