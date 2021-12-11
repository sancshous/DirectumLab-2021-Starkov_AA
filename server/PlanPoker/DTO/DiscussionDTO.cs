using System;
using System.Collections.Generic;

namespace PlanPoker.DTO
{
  public class DiscussionDTO
  {
    public Guid Id { get; set; }

    public Guid RoomID { get; set; }

    public string Title { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public IEnumerable<VoteDTO> Votes { get; set; }
  }
}
