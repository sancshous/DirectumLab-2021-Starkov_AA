using System;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class CardContext : ApiContext<Card>
  {
    public CardContext(DbContextOptions<CardContext> options) : base(options)
    {
      this.Elements.Add(new Card(new Guid(), 0, "zero"));
      this.Elements.Add(new Card(new Guid(), 1, "first"));
      this.Elements.Add(new Card(new Guid(), 1, "first"));
      this.Elements.Add(new Card(new Guid(), 2, "second"));
      this.Elements.Add(new Card(new Guid(), 3, "third"));
      this.Elements.Add(new Card(new Guid(), 5, "four"));
      this.Elements.Add(new Card(new Guid(), 8, "eight"));
      this.Elements.Add(new Card(new Guid(), 13, "thirteen"));
      this.Elements.Add(new Card(new Guid(), 21, "twenty one"));
      this.Elements.Add(new Card(new Guid(), 34, "thirty four"));
      this.Elements.Add(new Card(new Guid(), 55, "fifty five"));
      this.Elements.Add(new Card(new Guid(), 89, "eighty nine"));
      this.Elements.Add(new Card(new Guid(), null, "question"));
    }
  }
}
