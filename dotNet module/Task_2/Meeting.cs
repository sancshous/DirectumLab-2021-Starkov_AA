using System;

namespace Task_2
{
  /// <summary>
  /// Встреча.
  /// </summary>
  public class Meeting
  {
    private DateTime startMeeting;
    private DateTime endMeeting;

    /// <summary>
    /// Встреча.
    /// </summary>
    /// <param name="startMeeting">Начало встречи.</param>
    /// <param name="endMeeting">Конец встречи.</param>
    public Meeting(DateTime startMeeting, DateTime endMeeting)
    {
      this.startMeeting = startMeeting;
      this.endMeeting = endMeeting;
    }

    /// <summary>
    /// Начало встречи.
    /// </summary>
    public virtual DateTime StartMeeting
    {
      get => this.startMeeting;
      set
      {
        if (value < this.endMeeting)
          this.startMeeting = value;
      }
    }

    /// <summary>
    /// Конец встречи.
    /// </summary>
    public virtual DateTime EndMeeting 
    { 
      get => this.endMeeting;
      set
      {
        if (value > this.startMeeting)
          this.endMeeting = value;
      }
    }

    /// <summary>
    /// Продолжительность.
    /// </summary>
    public virtual TimeSpan Duration => this.endMeeting.Subtract(this.startMeeting);

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Начало встречи: " + this.StartMeeting + "\nОкончание встречи: " + this.EndMeeting + "\nПродолжительность встречи: " + this.Duration;
    }
  }

}
