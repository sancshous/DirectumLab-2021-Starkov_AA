using Microsoft.EntityFrameworkCore;
using PlanPoker.Infrastructure.Contexts;

namespace Tests.TestContext
{
  public class VoteTestContext
  {
    public VoteContext Context { get; set; }

    public VoteTestContext()
    {
      var builder = new DbContextOptionsBuilder<VoteContext>();
      builder.UseInMemoryDatabase("VoteTests");

      this.Context = new VoteContext(builder.Options);

      this.Context.Elements.Add(TestData.GetTestVote());

      this.Context.SaveChanges();
    }
  }
}
