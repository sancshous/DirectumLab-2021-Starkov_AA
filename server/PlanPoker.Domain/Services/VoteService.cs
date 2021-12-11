using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class VoteService
  {
    private readonly IRepository<Vote> repository;

    public VoteService(IRepository<Vote> repository)
    {
      this.repository = repository;
    }

    public Vote Create(Guid cardId, Guid roomId, Guid userId, Guid discussionId)
    {
      var id = Guid.NewGuid();
      var vote = new Vote(id, cardId, roomId, userId, discussionId);
      this.repository.Create(vote);
      this.repository.Save();
      return vote;
    }

    public void ChangeVote(Guid voteId, Guid cardId)
    {
      var discussionId = this.repository.Get(voteId).DiscussionId;
      var userId = this.repository.Get(voteId).UserId;
      var roomId = this.repository.Get(voteId).RoomId;
      var vote = new Vote(voteId, cardId, roomId, userId, discussionId);
      this.repository.Create(vote);
      this.repository.Save();
    }

    public Vote GetVote(Guid id)
    {
      return this.repository.Get(id);
    }

    public IQueryable<Vote> GetVotes()
    {
      return this.repository.GetAll();
    }
  }
}
