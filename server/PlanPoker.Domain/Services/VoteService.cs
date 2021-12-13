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
      var votes = this.GetVotes(discussionId).ToList();
      if (votes.Any(vote => vote.UserId == userId) && votes.Any(vote => vote.CardId != cardId))
      {
        this.repository.Delete(votes.Find(vote => vote.UserId == userId));
        var id = Guid.NewGuid();
        var vote = new Vote(id, cardId, roomId, userId, discussionId);
        this.repository.Add(vote);
        this.repository.Save();
        return vote;
      }
      else
      {
        var id = Guid.NewGuid();
        var vote = new Vote(id, cardId, roomId, userId, discussionId);
        this.repository.Add(vote);
        this.repository.Save();
        return vote;
      }
    }

    public Vote GetVote(Guid id)
    {
      return this.repository.Get(id);
    }

    public IQueryable<Vote> GetVotes(Guid discussionId)
    {
      return this.repository.GetAll().Where(vote => vote.DiscussionId == discussionId);
    }
  }
}
