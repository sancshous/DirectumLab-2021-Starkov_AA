using System;
using System.Collections.Generic;
using System.Text;
using Task_2;

namespace Task_4
{
  /// <summary>
  /// Встреча без конца.
  /// </summary>
  public class MeetWithoutEnd : Meeting
  {
    private DateTime? endMeeting;
    private DateTime startMeeting;

    /// <summary>
    /// EndMeeting.
    /// </summary>
    public override DateTime EndMeeting
    {
      get
      {
        if (this.endMeeting.HasValue)
          return this.endMeeting.Value;
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

    /// <summary>
    /// Duration.
    /// </summary>
    public override TimeSpan Duration
    {
      get 
      {
        if (this.endMeeting.HasValue)
        {
          return base.Duration;
        }
        else
        {
          Console.Write("Продолжительность встречи неизвестна.\n");
          return TimeSpan.MaxValue;
        }
      }
    }

    /// <summary>
    /// Встреча без конца.
    /// </summary>
    /// <param name="startMeeting">Начало встречи.</param>
    /// <param name="endMeeting">Конец встречи.</param>
    public MeetWithoutEnd(DateTime startMeeting, DateTime? endMeeting) : base(startMeeting, endMeeting ?? DateTime.MaxValue)
    {
      this.startMeeting = startMeeting;
      if (endMeeting.HasValue)
        this.endMeeting = (DateTime)endMeeting;
      else
        this.endMeeting = endMeeting;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Начало встречи: " + this.startMeeting + "\nОкончание встречи: " + this.EndMeeting + "\nПродолжительность встречи: " + this.Duration + "\n";
    }
  }
}
