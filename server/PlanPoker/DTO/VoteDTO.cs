using System;
using PlanPoker.Domain.Entities;

namespace PlanPoker.DTO
{
  public class VoteDTO
  {
    public Guid Id { get; set; }

    public Card Card { get; set; }

    public Guid RoomId { get; set; }

    public Guid UserId { get; set; }

    public Guid DiscussionId { get; set; }
  }
}
