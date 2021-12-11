using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class VoteDTOBuilder
  {
    public static VoteDTO Build(Vote vote, CardService cardService)
    {
      var card = cardService.GetCard(vote.CardId);
      return new VoteDTO()
      {
        Id = vote.Id,
        Card = card,
        RoomId = vote.RoomId,
        UserId = vote.UserId,
        DiscussionId = vote.DiscussionId
      };
    }

    public static IEnumerable<VoteDTO> BuildList(IEnumerable<Vote> votes, CardService cardService)
    {
      return votes.Select(vote => Build(vote, cardService));
    }
  }
}
