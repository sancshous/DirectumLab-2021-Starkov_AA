using System;
using System.Collections.Generic;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Комната планирования.
  /// </summary>
  public class Room : Entity
  {
    /// <summary>
    /// Название комнаты.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Список участников.
    /// </summary>
    public virtual ICollection<User> Users { get; private set; }

    /// <summary>
    /// Создатель комнаты(он же и ведущий, т.е. начинает обсуждение).
    /// </summary>
    public Guid OwnerId { get; set; }

    public ICollection<Discussion> Discussions { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id комнаты.</param>
    /// <param name="title">Название комнаты.</param>
    /// <param name="ownerId">Создатель комнаты.</param>
    public Room(Guid id, string title, Guid ownerId) : base(id)
    {
      this.Title = title;
      this.OwnerId = ownerId;
      this.Users = new List<User>();
      this.Discussions = new List<Discussion>();
    }
  }
}
