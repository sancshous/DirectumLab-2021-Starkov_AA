using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class DiscussionDTOBuilder
  {
    public static DiscussionDTO Build(Discussion discussion, CardService cardService, DiscussionService discussionService)
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
        AverageVote = Math.Round((double)discussionService.CalculateAverageVote(discussion.Id), 2)
      };
    }

    public static DiscussionDTO[] BuildList(IEnumerable<Discussion> discussions, CardService cardService, DiscussionService discussionService)
    {
      return discussions.Select(discussion => Build(discussion, cardService, discussionService)).ToArray();
    }
  }
}
