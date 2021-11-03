using System;

namespace Task_2
{
  public class Meeting
  {
    private DateTime startDate, endDate;
    private TimeSpan duration;
    public Meeting() { }
    public Meeting(DateTime startDate, DateTime endDate)
    {
      this.startDate = startDate;
      this.endDate = endDate;
      duration = endDate.Subtract(startDate);
    }

    public DateTime StartDate { get => startDate; set => startDate = value; }
    public DateTime EndDate { get => endDate; set => endDate = value; }
    public TimeSpan Duration => duration;

    //public void UpdateDuration(DateTime startDate, DateTime endDate) { duration = endDate.Subtract(startDate); }

  }
}
