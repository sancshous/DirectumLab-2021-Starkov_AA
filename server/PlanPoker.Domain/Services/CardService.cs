using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class CardService
  {
    private readonly IRepository<Card> repository;

    public CardService(IRepository<Card> repository)
    {
      this.repository = repository;
    }

    public Card GetCard(Guid id)
    {
      return this.repository.Get(id);
    }

    public IQueryable<Card> GetCards()
    {
      return this.repository.GetAll();
    }
  }
}
