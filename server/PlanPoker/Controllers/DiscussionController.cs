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
    public DiscussionDTO Create(Guid roomId, string title = "")
    {
      var discussion = this.discussionService.Create(roomId, title);
      return DiscussionDTOBuilder.Build(discussion, this.cardService, this.discussionService);
    }

    [HttpPost]
    public void Start(Guid discussionId, string start)
    {
      this.discussionService.Start(discussionId, start);
    }

    [HttpPost]
    public void Close(Guid discussionId)
    {
      this.discussionService.Close(discussionId);
    }

    [HttpGet]
    public VoteDTO AddVote(Guid cardId, Guid roomId, Guid userId, Guid discussionId)
    {
      var vote = this.voteService.Create(cardId, roomId, userId, discussionId);
      this.discussionService.AddVote(discussionId, vote);
      return VoteDTOBuilder.Build(vote, this.cardService);
    }

    [HttpGet]
    public IEnumerable<DiscussionDTO> GetDiscussionList(Guid roomId)
    {
      var discussions = this.discussionService.GetDiscussions(roomId);
      return DiscussionDTOBuilder.BuildList(discussions, this.cardService, this.discussionService);
    }
  }
}
