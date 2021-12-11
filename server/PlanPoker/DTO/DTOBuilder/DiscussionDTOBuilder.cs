using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class DiscussionDTOBuilder
  {
    public static DiscussionDTO Build(Discussion discussion, VoteService voteService, CardService cardService)
    {
      var votes = VoteDTOBuilder.BuildList(discussion.Votes.Select(id => voteService.GetVote(id)), cardService);
      return new DiscussionDTO()
      {
        Id = discussion.Id,
        RoomID = discussion.RoomId,
        Title = discussion.Title,
        Start = discussion.Start,
        End = discussion.End,
        Votes = votes
      };
    }

    public static IEnumerable<DiscussionDTO> BuildList(IEnumerable<Discussion> discussions, VoteService voteService, CardService cardService)
    {
      return discussions.Select(discussion => Build(discussion, voteService, cardService));
    }
  }
}
