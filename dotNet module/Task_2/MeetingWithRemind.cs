using System;
using System.Timers;

namespace Task_2
{
  class MeetingWithRemind : Meeting, IRemind
  {
    public System.Timers.Timer aTimer;
    private DateTime remindDate;

    public DateTime GetSetRemind { get => remindDate; set => remindDate = value; }

    public void SetTimer()
    {
      // Create a timer with a 5 second interval.
      aTimer = new System.Timers.Timer(5000);
      //aTimer.Interval = 1000;
      // Hook up the Elapsed event for the timer. 
      aTimer.Elapsed += Remind;
      aTimer.AutoReset = true;
      aTimer.Enabled = true;
    }
    private static void Remind(Object source, ElapsedEventArgs e)
    {
      Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);

    }

  }
}
