using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
  public class MeetWithTypeMeet : Meeting
  {
    private string meetType;

    public MeetWithTypeMeet(string meetType, DateTime startMeeting, DateTime endMeeting) : base(startMeeting, endMeeting)
    {
      MeetType = meetType;
    }

    public string MeetType
    {
      get => this.meetType;
      set
      {
        if (value == "совещание")
          this.meetType = value;
        else if (value == "поручение")
          this.meetType = value;
        else if (value == "звонок")
          this.meetType = value;
        else if (value == "день рождения")
          this.meetType = value;
        else
          Console.WriteLine("Неправильный тип встречи. Тип встречи может принимать только определенные значения: совещание, поручение, звонок, день рождения.");
      }
    }
    public override string ToString()
    {
      return "Тип встречи: " + MeetType + "\nНачало встречи: " + StartMeeting + "\nОкончание встречи: " + EndMeeting + "\nПродолжительность встречи: " + Duration + "\n";
    }

  }
}
