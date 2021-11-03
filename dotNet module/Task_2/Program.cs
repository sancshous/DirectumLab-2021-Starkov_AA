using System;

namespace Task_2
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Meeting a;
      DateTime startDate = new DateTime(2021, 11, 3, 17, 30, 25);
      DateTime endDate = new DateTime(2021, 11, 3, 18, 30, 25);
      if (startDate < endDate)
      {
        a = new Meeting(startDate, endDate);
        Console.WriteLine($"Дата начала: {a.StartDate} \nДата конца: {a.EndDate} \nПродолжительность: {a.Duration}");
      }
      else Console.WriteLine("Дата конца не может быть меньше даты начала");

      MeetingWithRemind b = new MeetingWithRemind();
      DateTime remindDate = new DateTime(2021, 11, 3, 16, 41, 25); // выставить значение которое немного больше DateTime.Now
      b.GetSetRemind = remindDate;
      while(b.GetSetRemind >= DateTime.Now)
      {
        b.SetTimer();
      }
      Console.WriteLine("Напоминание: Твоя встреча скоро начнется");
      b.aTimer.Stop();
      b.aTimer.Dispose();

    }
  }
}
