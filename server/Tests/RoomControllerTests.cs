using Moq;
using NUnit.Framework;
using PlanPoker.Controllers;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using PlanPoker.DTO.DTOBuilder;
using PlanPoker.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Text.Json;
using Tests.TestContext;

namespace Tests
{
  [TestFixture]
  public class RoomControllerTests
  {
    private RoomService roomService;
    private CardService cardService;
    private DiscussionService discussionService;
    private VoteService voteService;
    private UserService userService;

    [OneTimeSetUp]
    public void SetUpOnce()
    {
      var userContext = new UserTestContext().Context;
      var roomContext = new RoomTestContext().Context;
      var discussionContext = new DiscussionTestContext().Context;
      var cardContext = new CardTestContext().Context;
      var voteContext = new VoteTestContext().Context;

      var userMock = new Mock<IRepository<User>>();
      userMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(new UserRepository(userContext).Get(TestData.GetTestUser().Id));
      this.userService = new UserService(userMock.Object);

      var roomMock = new Mock<IRepository<Room>>();
      roomMock.Setup(repository => repository.GetAll()).Returns(new RoomRepository(roomContext).GetAll());
      this.roomService = new RoomService(roomMock.Object, userMock.Object);

      var cardMock = new Mock<IRepository<Card>>();
      cardMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(new CardRepository(cardContext).Get(TestData.GetTestCard().Id));
      this.cardService = new CardService(cardMock.Object);

      var discusMock = new Mock<IRepository<Discussion>>();
      discusMock.Setup(repository => repository.GetAll()).Returns(new DiscussionRepository(discussionContext).GetAll());
      this.discussionService = new DiscussionService(discusMock.Object, cardMock.Object);

      var voteMock = new Mock<IRepository<Vote>>();
      voteMock.Setup(repository => repository.GetAll()).Returns(new VoteRepository(voteContext).GetAll());
      this.voteService = new VoteService(voteMock.Object);

    }

    [Test]
    public void GetRoomInfoTest()
    {
      var roomId = TestData.GetTestRoom().Id;
      var room = this.roomService.GetRooms().First(room => room.Id == roomId);
      var discussions = this.discussionService.GetDiscussions(room.Id);
      var expected = RoomDTOBuilder.Build(room, discussions, this.cardService, this.discussionService);

      var roomController = new RoomController(this.roomService, this.discussionService, this.cardService);
      var actual = roomController.GetRoomInfo(roomId);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

  }
}
