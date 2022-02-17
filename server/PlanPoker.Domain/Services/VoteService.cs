using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class VoteService
  {
    private readonly IRepository<Vote> repository;

    private readonly IRepository<Discussion> disRepository;

    public VoteService(IRepository<Vote> repository, IRepository<Discussion> disRepository)
    {
      this.repository = repository;
      this.disRepository = disRepository;
    }

    public Vote Create(Guid cardId, Guid userId, Guid discussionId)
    {
      var votes = this.GetVotes(discussionId).ToList();
      if (votes.Any(vote => vote.UserId == userId))
      {
        var discus = this.disRepository.GetAll().First(d => d.Id == discussionId);
        var vote = discus.Votes.First(v => v.UserId == userId);
        var vote1 = this.repository.Get(votes.Find(vote => vote.UserId == userId).Id);
        this.repository.Delete(vote1);
        discus.Votes.Remove(vote);
        this.disRepository.Save();
        vote.CardId = cardId;
        vote.Id = Guid.NewGuid();
        this.repository.Add(vote);
        this.repository.Save();
        return vote;
      }
      else
      {
        var id = Guid.NewGuid();
        var vote = new Vote(id, cardId, userId, discussionId);
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
