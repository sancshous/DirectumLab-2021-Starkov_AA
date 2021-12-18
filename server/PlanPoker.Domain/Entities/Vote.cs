using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Оценка.
  /// </summary>
  public class Vote : Entity
  {
    /// <summary>
    /// Id карты.
    /// </summary>
    public Guid CardId { get; set; }

    /// <summary>
    /// Id комнаты.
    /// </summary>
    public Guid RoomId { get; set; }

    /// <summary>
    /// Id игрока.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Id обсуждения.
    /// </summary>
    public Guid DiscussionId { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id оценки.</param>
    /// <param name="cardId">Id карты.</param>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id участника.</param>
    /// <param name="discussionId">Id обсуждения.</param>
    public Vote(Guid id, Guid cardId, Guid roomId, Guid userId, Guid discussionId) : base(id)
    {
      this.CardId = cardId;
      this.RoomId = roomId;
      this.UserId = userId;
      this.DiscussionId = discussionId;
    }
  }
}
