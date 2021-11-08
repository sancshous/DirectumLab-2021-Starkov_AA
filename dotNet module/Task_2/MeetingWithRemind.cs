using System;
using System.Timers;

namespace Task_2
{
  public class MeetingWithRemind : Meeting, IRemind
  {
    public System.Timers.Timer timer;
    private DateTime remind;

    public DateTime Remind { get => this.remind; set => this.remind = value; }

    public void SetTimer()
    {
      // Create a timer with a 2 second interval.
      this.timer = new System.Timers.Timer(2000);
      // Hook up the Elapsed event for the timer. 
      this.timer.Elapsed += OnTimedEvent;
      this.timer.AutoReset = true;
      this.timer.Enabled = true;
    }
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      if (DateTime.Now >= this.remind)
        ShowRemind();
    }

    private void ShowRemind()
    {
      Console.WriteLine("Напоминание: Твоя встреча скоро начнется!");
      this.timer.Stop();
    }
  }
}
