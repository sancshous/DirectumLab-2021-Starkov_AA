using System;

namespace PlanPoker.Domain.Entities
{
  public class Entity : IEntity
  {
    /// <summary>
    /// Id сущности.
    /// </summary>
    public Guid Id { get; set; }
  }
}
