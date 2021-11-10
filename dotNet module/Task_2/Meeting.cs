using System;

namespace Task_2
{
  public class Meeting
  {
    private DateTime startMeeting, endMeeting;
    public Meeting() { }

    public Meeting(DateTime startMeeting, DateTime endMeeting)
    {
      StartMeeting = startMeeting;
      EndMeeting = endMeeting;
    }

    public virtual DateTime StartMeeting { get; set; }
    public virtual DateTime EndMeeting 
    { 
      get => this.endMeeting;
      set
      {
        if (value > this.startMeeting)
          this.endMeeting = value;
      }
    }
    public virtual TimeSpan Duration => this.endMeeting.Subtract(this.startMeeting);

    public override string ToString()
    {
      return "Начало встречи: " + StartMeeting + "\nОкончание встречи: " + EndMeeting + "\nПродолжительность встречи: " + Duration;
    }
  }

}
