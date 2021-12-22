using System;
using System.Collections.Generic;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Обсуждение.
  /// </summary>
  public class Discussion : Entity
  {
    /// <summary>
    /// Id комнаты.
    /// </summary>
    public Guid RoomId { get; set; }

    /// <summary>
    /// Тема обсуждения.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Время начала обсуждения.
    /// </summary>
    public DateTime? Start { get; set; }

    /// <summary>
    /// Время конца обсуждения.
    /// </summary>
    public DateTime? End { get; set; }

    /// <summary>
    /// Id голосований из обсуждения.
    /// </summary>
    public ICollection<Vote> Votes { get; }

    public double? AverageVote { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id обсуждения.</param>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="title">Тема обсуждения.</param>
    public Discussion(Guid id, Guid roomId, string title) : base(id)
    {
      this.RoomId = roomId;
      this.Title = title;
      this.Votes = new List<Vote>();
      this.AverageVote = 0;
    }
  }
}
