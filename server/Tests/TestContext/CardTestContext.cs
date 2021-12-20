using Microsoft.EntityFrameworkCore;
using PlanPoker.Infrastructure.Contexts;

namespace Tests.TestContext
{
  public class CardTestContext
  {
    public CardContext Context { get; set; }

    public CardTestContext()
    {
      var builder = new DbContextOptionsBuilder<CardContext>();
      builder.UseInMemoryDatabase("CardTests");

      this.Context = new CardContext(builder.Options);

      this.Context.Elements.Add(TestData.GetTestCard());

      this.Context.SaveChanges();
    }
  }
}
