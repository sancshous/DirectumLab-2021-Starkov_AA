using System;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class CardContext : ApiContext<Card>
  {
    public CardContext(DbContextOptions<CardContext> options) : base(options)
    {
      /*foreach (var entity in this.Elements)
        this.Elements.Remove(entity);
      var card1 = new Card(Guid.NewGuid(), 0, "zero");
      var card2 = new Card(Guid.NewGuid(), 0.5, "zeropointfive");
      var card3 = new Card(Guid.NewGuid(), 1, "first");
      var card4 = new Card(Guid.NewGuid(), 2, "second");
      var card5 = new Card(Guid.NewGuid(), 3, "third");
      var card6 = new Card(Guid.NewGuid(), 5, "five");
      var card7 = new Card(Guid.NewGuid(), 8, "eight");
      var card8 = new Card(Guid.NewGuid(), 13, "thirteen");
      var card9 = new Card(Guid.NewGuid(), 20, "twenty");
      var card10 = new Card(Guid.NewGuid(), 40, "fourty");
      var card11 = new Card(Guid.NewGuid(), 100, "onehundred");
      var card12 = new Card(Guid.NewGuid(), -10, "question");
      var card13 = new Card(Guid.NewGuid(), -100, "coffee");
      this.Elements.AddRange(card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11, card12, card13);
      this.SaveChanges();*/
    }
  }
}
