using Microsoft.EntityFrameworkCore;
using PlanPoker.Infrastructure.Contexts;

namespace Tests.TestContext
{
  public class DiscussionTestContext
  {
    public DiscussionContext Context { get; set; }

    public DiscussionTestContext()
    {
      var builder = new DbContextOptionsBuilder<DiscussionContext>();
      builder.UseInMemoryDatabase("DiscussionsTests");

      this.Context = new DiscussionContext(builder.Options);

      this.Context.Elements.Add(TestData.GetTestDiscussion(TestData.GetTestRoom(TestData.GetTestUser())));

      this.Context.SaveChanges();
    }
  }
}
