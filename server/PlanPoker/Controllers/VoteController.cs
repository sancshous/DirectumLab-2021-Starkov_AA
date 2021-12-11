using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
using PlanPoker.DTO.DTOBuilder;

namespace PlanPoker.Controllers
{
  [ApiController]
  [Route("/api/[controller]/[action]")]
  public class VoteController
  {
    private readonly VoteService voteService;

    private readonly CardService cardService;

    public VoteController(VoteService voteService, CardService cardService)
    {
      this.voteService = voteService;
      this.cardService = cardService;
    }

    [HttpGet]
    public VoteDTO Create(string cardId, string roomId, string userId, string discussionId)
    {
      var cardGuid = Guid.Parse(cardId.Replace(" ", string.Empty));
      var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
      var userGuid = Guid.Parse(userId.Replace(" ", string.Empty));
      var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));

      var vote = this.voteService.Create(cardGuid, roomGuid, userGuid, discussionGuid);
      return VoteDTOBuilder.Build(vote, this.cardService);
    }

    [HttpPost]
    public void ChangeVote(string voteId, string cardId)
    {
      var voteGuid = Guid.Parse(voteId.Replace(" ", string.Empty));
      var cardGuid = Guid.Parse(cardId.Replace(" ", string.Empty));
      this.voteService.ChangeVote(voteGuid, cardGuid);
    }

    [HttpGet]
    public IEnumerable<VoteDTO> GetVotes()
    {
      var votes = this.voteService.GetVotes();
      return VoteDTOBuilder.BuildList(votes, this.cardService);
    }
  }
}
