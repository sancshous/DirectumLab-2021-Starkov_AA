using System;

namespace Task_2
{
  public class Meeting
  {
    private DateTime startMeeting, endMeeting;
    public Meeting() { }
    public Meeting(DateTime startMeeting, DateTime endMeeting)
    {
      this.startMeeting = startMeeting;
      this.endMeeting = endMeeting;
    }

    public DateTime StartMeeting 
    {
      get => this.startMeeting;
      set
      {
        if (value < this.endMeeting)
          this.startMeeting = value;
      }
    }
    public DateTime EndMeeting 
    { 
      get => this.endMeeting;
      set
      {
        if (value > this.startMeeting)
          this.endMeeting = value;
      }
    }
    public TimeSpan Duration => this.endMeeting.Subtract(this.startMeeting);
  }
}
