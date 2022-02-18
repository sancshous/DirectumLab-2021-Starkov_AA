using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class CardContext : ApiContext<Card>
  {
    public CardContext(DbContextOptions<CardContext> options) : base(options)
    {
      foreach (var entity in this.Elements)
        this.Elements.Remove(entity);
      var card1 = new Card(Guid.Parse("4b543ed7-9a5c-42b7-9f45-9902d2ba7ef8"), 0, "zero");
      var card2 = new Card(Guid.Parse("81042fa0-2a0c-4ac6-b88b-76262ca1ed26"), 0.5, "zeropointfive");
      var card3 = new Card(Guid.Parse("e0afecaa-ea62-4233-be0e-5f68df780755"), 1, "first");
      var card4 = new Card(Guid.Parse("b64988a5-8ee8-40b4-ba41-2c2cc23d41aa"), 2, "second");
      var card5 = new Card(Guid.Parse("e2639286-4b09-46dc-83de-5bf6d19cb28d"), 3, "third");
      var card6 = new Card(Guid.Parse("0896a662-50a4-4490-a229-8c1344adc73f"), 5, "five");
      var card7 = new Card(Guid.Parse("409e1552-331b-4533-b359-0b104bf3395b"), 8, "eight");
      var card8 = new Card(Guid.Parse("76e780b5-a506-413d-bd48-26b0d77c1469"), 13, "thirteen");
      var card9 = new Card(Guid.Parse("476092fd-4d22-4e6c-adc8-79c1d0644a40"), 20, "twenty");
      var card10 = new Card(Guid.Parse("6f5e844b-7b6c-4422-8a16-5b994f5c4e92"), 40, "fourty");
      var card11 = new Card(Guid.Parse("5c16289b-9051-49d4-a407-8c78d2215380"), 100, "onehundred");
      var card12 = new Card(Guid.Parse("228105e8-bcf0-444f-8a95-590a4dba44d1"), -10, "question");
      var card13 = new Card(Guid.Parse("d3ab380a-cf6c-4ac5-8ac2-5e1f52be977c"), -100, "coffee");
      this.Elements.AddRange(card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11, card12, card13);
      this.SaveChanges();
    }
  }
}
