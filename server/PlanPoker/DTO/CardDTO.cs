using System;

namespace PlanPoker.DTO
{
  public class CardDTO
  {
    public Guid Id { get; set; }

    public int? Value { get; set; }

    public string Title { get; set; }
  }
}
