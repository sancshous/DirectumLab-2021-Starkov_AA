using Microsoft.EntityFrameworkCore;
using PlanPoker.Infrastructure.Contexts;

namespace Tests.TestContext
{
  public class UserTestContext
  {
    public UserContext Context { get; set; }

    public UserTestContext()
    {
      var builder = new DbContextOptionsBuilder<UserContext>();
      builder.UseInMemoryDatabase("UserTests");

      this.Context = new UserContext(builder.Options);

      this.Context.Elements.Add(TestData.GetTestUser());

      this.Context.SaveChanges();
    }
  }
}
