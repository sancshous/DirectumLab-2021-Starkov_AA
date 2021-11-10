using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{

  public class MeetWithoutEnd : Meeting
  {
    private DateTime? endMeeting;
    private DateTime startMeeting;
    public override DateTime EndMeeting
    {
      get
      {
        if (this.endMeeting.HasValue)
          return (DateTime)this.endMeeting;
        else
        {
          Console.WriteLine("Дата окончания встречи неизвестна.");
          return DateTime.MinValue;
        }
      }
      set
      {
        if (value == null)
        {
          this.endMeeting = null;
        }
        else
          this.endMeeting = value;
      }
    }
    public override TimeSpan Duration
    {
      get 
      {
        if (this.endMeeting == null)
        {
          Console.Write("Продолжительность встречи неизвестна.\n");
          return TimeSpan.Zero;
        }
        else
           return (TimeSpan)(this.endMeeting - this.startMeeting);
      }
    }
    public MeetWithoutEnd(DateTime startMeeting, DateTime? endMeeting) : base()
    {
      StartMeeting = startMeeting;
      if (endMeeting.HasValue)
        this.endMeeting = (DateTime)endMeeting;
      else
        this.endMeeting = endMeeting;
    }
    public override string ToString()
    {
      return "Начало встречи: " + StartMeeting + "\nОкончание встречи: " + EndMeeting + "\nПродолжительность встречи: " + Duration + "\n";
    }
  }
}
