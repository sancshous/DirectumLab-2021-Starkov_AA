using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class DiscussionService
  {
    private readonly IRepository<Discussion> discussionRepository;

    private readonly IRepository<Card> cardRepository;

    public DiscussionService(IRepository<Discussion> discussionRepository, IRepository<Card> cardRepository)
    {
      this.discussionRepository = discussionRepository;
      this.cardRepository = cardRepository;
    }

    public Discussion Create(Guid roomId, string title)
    {
      var id = Guid.NewGuid();
      var discussion = new Discussion(id, roomId, title);
      this.discussionRepository.Add(discussion);
      this.discussionRepository.Save();
      return discussion;
    }

    public DateTime Start(Guid discussionId, string startString)
    {
      if (DateTime.TryParse(startString, out DateTime startDateTime))
      {
        this.discussionRepository.Get(discussionId).Start = startDateTime;
        this.discussionRepository.Save();
        return startDateTime;
      }
      else
      {
        this.discussionRepository.Get(discussionId).Start = null;
        this.discussionRepository.Save();
        return startDateTime;
      }
    }

    public void Close(Guid discussionId)
    {
      this.discussionRepository.Get(discussionId).End = DateTime.Now;
      this.discussionRepository.Save();
    }

    public double? CalculateAverageVote(Guid discussionId)
    {
      var votes = this.GetVotes(discussionId);
      var values = votes.Select(v => this.cardRepository.Get(v.CardId)).ToArray();
      if (!values.Any())
        return 0;
      return values.Where(v => v.Value.HasValue).Average(v => v.Value.Value);
    }

    public void AddVote(Guid discussionId, Vote vote)
    {
      this.discussionRepository.Get(discussionId).Votes.Add(vote);
      this.discussionRepository.Save();
    }

    public ICollection<Vote> GetVotes(Guid discussionId)
    {
      return this.discussionRepository.Get(discussionId).Votes;
    }

    public Discussion GetDiscussion(Guid id)
    {
      return this.discussionRepository.Get(id);
    }

    public IQueryable<Discussion> GetDiscussions(Guid roomId)
    {
      return this.discussionRepository.GetAll().Where(discussion => discussion.RoomId == roomId);
    }
  }
}
