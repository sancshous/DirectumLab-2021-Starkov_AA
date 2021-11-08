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
      get => startMeeting;
      set
      {
        if (startMeeting < endMeeting)
          startMeeting = value;
      }
    }
    public DateTime EndMeeting 
    { 
      get => endMeeting;
      set
      {
        if (startMeeting < endMeeting)
          endMeeting = value;
      }
    }
    public TimeSpan Duration => endMeeting.Subtract(startMeeting);
  }
}
