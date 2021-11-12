using System;
using System.Collections.Generic;
using System.Text;
using Task_2;

namespace Task_4
{
  /// <summary>
  /// Тип встречи.
  /// </summary>
  public enum MeetingType
  {
    /// <summary>
    /// Совещание. 
    /// </summary>
    Сonference,

    /// <summary>
    /// Поручение.
    /// </summary>
    Assignment,

    /// <summary>
    /// Звонок.
    /// </summary>
    Call,

    /// <summary>
    /// День рождения.
    /// </summary>
    Birthday
  }

  /// <summary>
  /// Встреча с указанием типа встречи.
  /// </summary>
  public class MeetWithTypeMeet : Meeting
  {
    /// <summary>
    /// Встреча с указанием типа встречи.
    /// </summary>
    /// <param name="type">Тип встречи.</param>
    /// <param name="startMeeting">Начало встречи.</param>
    /// <param name="endMeeting">Конец встречи.</param>
    public MeetWithTypeMeet(MeetingType type, DateTime startMeeting, DateTime endMeeting) : base(startMeeting, endMeeting)
    {
      this.Type = type;
    }

    /// <summary>
    /// Тип встречи.
    /// </summary>
    public MeetingType Type { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Тип встречи: " + this.Type + "\nНачало встречи: " + this.StartMeeting + "\nОкончание встречи: " + this.EndMeeting + "\nПродолжительность встречи: " + this.Duration + "\n";
    }
  }
}
