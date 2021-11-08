using System;
using System.Timers;

namespace Task_2
{
  class MeetingWithRemind : Meeting, IRemind
  {
    public System.Timers.Timer timer;
    private DateTime remind;

    public DateTime Remind { get => remind; set => remind = value; }

    public void SetTimer()
    {
      // Create a timer with a 2 second interval.
      timer = new System.Timers.Timer(2000);
      // Hook up the Elapsed event for the timer. 
      timer.Elapsed += OnTimedEvent;
      timer.AutoReset = true;
      timer.Enabled = true;
    }
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      if (remind >= DateTime.Now)
        TRemind();
      else
        timer.Stop();
    }

    private void TRemind()
    {
      Console.WriteLine($"The Elapsed event was raised at {DateTime.Now}");
    }
  }
}
