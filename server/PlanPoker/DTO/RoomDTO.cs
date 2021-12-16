using System;
using System.Collections.Generic;

namespace PlanPoker.DTO
{
  public class RoomDTO
  {
    public Guid Id { get; set; }

    public string Title { get; set; }

    public Guid OwnerId { get; set; }

    public IEnumerable<UserDTO> Users { get; set; }

    public IEnumerable<DiscussionDTO> Discussions { get; set; }
  }
}
