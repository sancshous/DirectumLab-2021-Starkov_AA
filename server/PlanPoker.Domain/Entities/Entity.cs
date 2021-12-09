using System;

namespace PlanPoker.Domain.Entities
{
  public abstract class Entity : IEntity
  {
    /// <summary>
    /// Id сущности.
    /// </summary>
    public Guid Id { get; }

    public Entity(Guid id)
    {
      this.Id = id;
    }
  }
}