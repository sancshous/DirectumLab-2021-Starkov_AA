using System;

namespace PlanPoker.DTO
{
  public class CardDTO
  {
    public Guid Id { get; set; }

    public double? Value { get; set; }

    public string Title { get; set; }
  }
}
