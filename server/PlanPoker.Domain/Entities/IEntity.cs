using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Сущность.
  /// </summary>
  public interface IEntity
  {
    /// <summary>
    /// Id сущности.
    /// </summary>
    Guid Id { get; }
  }
}
