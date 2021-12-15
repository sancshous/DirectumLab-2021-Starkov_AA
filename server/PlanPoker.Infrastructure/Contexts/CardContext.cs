using System;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class CardContext : ApiContext<Card>
  {
    public CardContext(DbContextOptions<CardContext> options) : base(options)
    {
      this.Elements.Add(new Card(Guid.NewGuid(), 0, "zero"));
      this.Elements.Add(new Card(Guid.NewGuid(), 1, "first"));
      this.Elements.Add(new Card(Guid.NewGuid(), 1, "first"));
      this.Elements.Add(new Card(Guid.NewGuid(), 2, "second"));
      this.Elements.Add(new Card(Guid.NewGuid(), 3, "third"));
      this.Elements.Add(new Card(Guid.NewGuid(), 5, "five"));
      this.Elements.Add(new Card(Guid.NewGuid(), 8, "eight"));
      this.Elements.Add(new Card(Guid.NewGuid(), 13, "thirteen"));
      this.Elements.Add(new Card(Guid.NewGuid(), 21, "twenty one"));
      this.Elements.Add(new Card(Guid.NewGuid(), 34, "thirty four"));
      this.Elements.Add(new Card(Guid.NewGuid(), 55, "fifty five"));
      this.Elements.Add(new Card(Guid.NewGuid(), 89, "eighty nine"));
      this.Elements.Add(new Card(Guid.NewGuid(), null, "question"));
    }
  }
}
