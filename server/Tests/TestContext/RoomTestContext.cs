using Microsoft.EntityFrameworkCore;
using PlanPoker.Infrastructure.Contexts;

namespace Tests.TestContext
{
  public class RoomTestContext
  {
    public RoomContext Context { get; set; }

    public RoomTestContext()
    {
      var builder = new DbContextOptionsBuilder<RoomContext>();
      builder.UseInMemoryDatabase("RoomTests");

      this.Context = new RoomContext(builder.Options);

      this.Context.Elements.Add(TestData.GetTestRoom(TestData.GetTestUser()));

      this.Context.SaveChanges();
    }
  }
}
