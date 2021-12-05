using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Участник планирования.
  /// </summary>
  public class User : IEntity
  {
    /// <summary>
    /// Id участника.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя участника.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id участника.</param>
    /// <param name="name">Имя участника.</param>
    public User(Guid id, string name)
    {
      this.Id = id;
      this.Name = name;
    }
  }
}
