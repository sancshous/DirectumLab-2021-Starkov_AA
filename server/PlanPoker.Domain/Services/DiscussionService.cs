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

    public DiscussionService(IRepository<Discussion> repository)
    {
      this.repository = repository;
    }

    public Discussion Create(Guid roomId, string title)
    {
      var id = Guid.NewGuid();
      var discussion = new Discussion(id, roomId, title);
      this.repository.Create(discussion);
      this.repository.Save();
      return discussion;
    }

    public void Close(Guid discussionId)
    {
      this.repository.Get(discussionId).End = DateTime.Now;
    }

    public void AddVote(Guid discussionId, Guid voteId)
    {
      this.repository.Get(discussionId).Votes.Add(voteId);
    }

    public ICollection<Guid> GetVotes(Guid discussionId)
    {
      return this.repository.Get(discussionId).Votes;
    }

    public Discussion GetDiscussion(Guid id)
    {
      return this.repository.Get(id);
    }

    public IQueryable<Discussion> GetDiscussions()
    {
      return this.repository.GetAll();
    }
  }
}
