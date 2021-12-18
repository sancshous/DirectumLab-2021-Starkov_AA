using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class DiscussionService
  {
    private readonly IRepository<Discussion> repository;

    private readonly IRepository<Card> cardRepository;

    public DiscussionService(IRepository<Discussion> repository, IRepository<Card> cardRepository)
    {
      this.repository = repository;
      this.cardRepository = cardRepository;
    }

    public Discussion Create(Guid roomId, string title)
    {
      var id = Guid.NewGuid();
      var discussion = new Discussion(id, roomId, title);
      this.repository.Add(discussion);
      this.repository.Save();
      return discussion;
    }

    public void Close(Guid discussionId)
    {
      this.repository.Get(discussionId).End = DateTime.Now;
      this.repository.Save();
    }

    public double? CalculateAverageVote(Guid discussionId)
    {
      var averageVote = this.repository.Get(discussionId).AverageVote;
      var votes = this.GetVotes(discussionId);
      foreach (var item in votes)
      {
        averageVote += this.cardRepository.Get(item.CardId).Value;
      }
      return averageVote;
    }

    public void AddVote(Guid discussionId, Vote vote)
    {
      this.repository.Get(discussionId).Votes.Add(vote);
      this.repository.Save();
    }

    public ICollection<Vote> GetVotes(Guid discussionId)
    {
      return this.repository.Get(discussionId).Votes;
    }

    public Discussion GetDiscussion(Guid id)
    {
      return this.repository.Get(id);
    }

    public IQueryable<Discussion> GetDiscussions(Guid roomId)
    {
      return this.repository.GetAll().Where(discussion => discussion.RoomId == roomId);
    }
  }
}
