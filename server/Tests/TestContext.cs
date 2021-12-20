using Microsoft.EntityFrameworkCore;
using PlanPoker.Infrastructure.Contexts;

namespace Tests
{
  public class TestContext
  {
    public CardContext CardContext { get; set; }

    public VoteContext VoteContext { get; set; }

    public DiscussionContext DiscusContext { get; set; }

    public RoomContext RoomContext { get; set; }

    public UserContext UserContext { get; set; }

    public TestContext()
    {
      var userBuilder = new DbContextOptionsBuilder<UserContext>();
      userBuilder.UseInMemoryDatabase("UserTests");
      this.UserContext = new UserContext(userBuilder.Options);
      this.UserContext.Database.EnsureDeleted();
      this.UserContext.Database.EnsureCreated();
      this.UserContext.Elements.Add(TestData.GetTestUser());
      this.UserContext.SaveChanges();

      var roomBuilder = new DbContextOptionsBuilder<RoomContext>();
      roomBuilder.UseInMemoryDatabase("RoomTests");
      this.RoomContext = new RoomContext(roomBuilder.Options);
      this.RoomContext.Database.EnsureDeleted();
      this.RoomContext.Database.EnsureCreated();
      this.RoomContext.Elements.Add(TestData.GetTestRoom());
      this.RoomContext.SaveChanges();

      var cardBuilder = new DbContextOptionsBuilder<CardContext>();
      cardBuilder.UseInMemoryDatabase("CardTests");
      this.CardContext = new CardContext(cardBuilder.Options);
      this.CardContext.Database.EnsureDeleted();
      this.CardContext.Database.EnsureCreated();
      this.CardContext.Elements.Add(TestData.GetTestCard());
      this.CardContext.SaveChanges();

      var discussionBuilder = new DbContextOptionsBuilder<DiscussionContext>();
      discussionBuilder.UseInMemoryDatabase("DiscussionTests");
      this.DiscusContext = new DiscussionContext(discussionBuilder.Options);
      this.DiscusContext.Database.EnsureDeleted();
      this.DiscusContext.Database.EnsureCreated();
      this.DiscusContext.Elements.Add(TestData.GetTestDiscussion());
      this.DiscusContext.SaveChanges();

      var voteBuilder = new DbContextOptionsBuilder<VoteContext>();
      voteBuilder.UseInMemoryDatabase("VoteTests");
      this.VoteContext = new VoteContext(voteBuilder.Options);
      this.VoteContext.Database.EnsureDeleted();
      this.VoteContext.Database.EnsureCreated();
      this.VoteContext.Elements.Add(TestData.GetTestVote());
      this.VoteContext.SaveChanges();
    }
  }
}
