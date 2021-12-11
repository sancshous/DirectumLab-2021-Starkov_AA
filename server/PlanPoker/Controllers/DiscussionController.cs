using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
using PlanPoker.DTO.DTOBuilder;

namespace PlanPoker.Controllers
{
  [ApiController]
  [Route("/api/[controller]/[action]")]
  public class DiscussionController
  {
    private readonly DiscussionService discussionService;

    private readonly VoteService voteService;

    private readonly CardService cardService;

    public DiscussionController(DiscussionService discussionService, VoteService voteService, CardService cardService)
    {
      this.discussionService = discussionService;
      this.voteService = voteService;
      this.cardService = cardService;
    }

    [HttpGet]
    public DiscussionDTO Create(string roomId, string title = "")
    {
      var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
      var discussion = this.discussionService.Create(roomGuid, title);
      return DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
    }

    [HttpPost]
    public void Close(string discussionId)
    {
      var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
      this.discussionService.Close(discussionGuid);
    }

    [HttpPost]
    public void AddVote(string discussionId, string voteId)
    {
      var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
      var voteGuid = Guid.Parse(voteId.Replace(" ", string.Empty));
      this.discussionService.AddVote(discussionGuid, voteGuid);
    }

    [HttpGet]
    public IEnumerable<VoteDTO> GetAllVotes(string discussionId)
    {
      var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
      var discussion = this.discussionService.GetDiscussion(discussionGuid);
      var votes = discussion.Votes.Select(id => this.voteService.GetVote(id));
      return VoteDTOBuilder.BuildList(votes, this.cardService);
    }

    [HttpGet]
    public IEnumerable<DiscussionDTO> GetDiscussionList()
    {
      var discussions = this.discussionService.GetDiscussions();
      return DiscussionDTOBuilder.BuildList(discussions, this.voteService, this.cardService);
    }
  }
}
