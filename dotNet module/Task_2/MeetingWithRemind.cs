using System;
using System.Timers;

namespace Task_2
{
  /// <summary>
  /// Встреча с напоминанием.
  /// </summary>
  public class MeetingWithRemind : Meeting, IRemind
  {
    public System.Timers.Timer timer;
    private DateTime remind;

    /// <summary>
    /// Реализация интерфейса Напоминание.
    /// </summary>
    public DateTime Remind { get => this.remind; set => this.remind = value; }

    /// <summary>
    /// Встреча с напоминанием.
    /// </summary>
    /// <param name="startMeeting">Начало встречи.</param>
    /// <param name="endMeeting">Конец встречи.</param>
    public MeetingWithRemind(DateTime startMeeting, DateTime endMeeting) : base(startMeeting, endMeeting)
    {

    }

    /// <summary>
    /// Создание таймера.
    /// </summary>
    public void SetTimer()
    {
      // Create a timer with a 2 second interval.
      this.timer = new Timer(2000);
      // Hook up the Elapsed event for the timer. 
      this.timer.Elapsed += this.OnTimedEvent;
      this.timer.AutoReset = true;
      this.timer.Enabled = true;
    }

    /// <summary>
    /// Обработчик события "Напоминание"
    /// </summary>
    /// <param name="source">Source.</param>
    /// <param name="e">e.</param>
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      if (DateTime.Now >= this.Remind)
        this.ShowRemind();
    }

    /// <summary>
    /// Показать напоминание.
    /// </summary>
    private void ShowRemind()
    {
      Console.WriteLine("Напоминание: Твоя встреча скоро начнется!");
      this.timer.Stop();
    }
  }
}
