using System;
using System.Collections.Generic;
using System.Text;
using Task_2;

namespace Task_4
{
  /// <summary>
  /// Тип встречи.
  /// </summary>
  public enum TypeMeet
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
    Bell,

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
    private TypeMeet meetType;

    /// <summary>
    /// Встреча с указанием типа встречи.
    /// </summary>
    /// <param name="meetType">Тип встречи.</param>
    /// <param name="startMeeting">Начало встречи.</param>
    /// <param name="endMeeting">Конец встречи.</param>
    public MeetWithTypeMeet(TypeMeet meetType, DateTime startMeeting, DateTime endMeeting) : base(startMeeting, endMeeting)
    {
      this.meetType = meetType;
    }

    /// <summary>
    /// Тип встречи.
    /// </summary>
    public TypeMeet MeetType { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Тип встречи: " + this.MeetType + "\nНачало встречи: " + this.StartMeeting + "\nОкончание встречи: " + this.EndMeeting + "\nПродолжительность встречи: " + this.Duration + "\n";
    }
  }
}
