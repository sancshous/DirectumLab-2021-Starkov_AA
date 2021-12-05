using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Комната планирования.
  /// </summary>
  public class Room : IEntity
  {
    /// <summary>
    /// Id комнаты.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название комнаты.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Список участников.
    /// </summary>
    public ICollection<Guid> Users { get; }

    /// <summary>
    /// Создатель комнаты(он же и ведущий, т.е. начинает обсуждение).
    /// </summary>
    public Guid OwnerId { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id комнаты.</param>
    /// <param name="title">Название комнаты.</param>
    /// <param name="ownerId">Создатель комнаты.</param>
    public Room(Guid id, string title, Guid ownerId)
    {
      this.Id = id;
      this.Title = title;
      this.OwnerId = ownerId;
      this.Users = new List<Guid>();
    }
  }
}
