using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class DiscussionDTOBuilder
  {
    public static DiscussionDTO Build(Discussion discussion, CardService cardService)
    {
      var votes = VoteDTOBuilder.BuildList(discussion.Votes, cardService);
      return new DiscussionDTO()
      {
        Id = discussion.Id,
        Title = discussion.Title,
        RoomID = discussion.RoomId,
        Start = discussion.Start,
        End = discussion.End,
        Votes = votes,
        AverageVote = discussion.AverageVote
      };
    }

    public static IEnumerable<DiscussionDTO> BuildList(IEnumerable<Discussion> discussions, CardService cardService)
    {
      return discussions.Select(discussion => Build(discussion, cardService));
    }
  }
}
