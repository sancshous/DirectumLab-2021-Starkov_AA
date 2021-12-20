using Moq;
using NUnit.Framework;
using PlanPoker.Controllers;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
using PlanPoker.DTO.DTOBuilder;
using PlanPoker.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Text.Json;

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
      var userContext = new TestContext().UserContext;
      var roomContext = new TestContext().RoomContext;
      var discussionContext = new TestContext().DiscusContext;
      var cardContext = new TestContext().CardContext;
      var voteContext = new TestContext().VoteContext;

      var userMock = new Mock<IRepository<User>>();
      userMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(new UserRepository(userContext).Get(TestData.GetTestUser().Id));
      userMock.Setup(repository => repository.GetAll()).Returns(new UserRepository(userContext).GetAll());
      this.userService = new UserService(userMock.Object);

      var roomMock = new Mock<IRepository<Room>>();
      roomMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(new RoomRepository(roomContext).Get(TestData.GetTestRoom().Id));
      roomMock.Setup(repository => repository.GetAll()).Returns(new RoomRepository(roomContext).GetAll());
      this.roomService = new RoomService(roomMock.Object, userMock.Object);

      var cardMock = new Mock<IRepository<Card>>();
      cardMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(new CardRepository(cardContext).Get(TestData.GetTestCard().Id));
      this.cardService = new CardService(cardMock.Object);

      var discusMock = new Mock<IRepository<Discussion>>();
      discusMock.Setup(repository => repository.GetAll()).Returns(new DiscussionRepository(discussionContext).GetAll());
      discusMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(new DiscussionRepository(discussionContext).Get(TestData.GetTestDiscussion().Id));
      this.discussionService = new DiscussionService(discusMock.Object, cardMock.Object);

      var voteMock = new Mock<IRepository<Vote>>();
      voteMock.Setup(repository => repository.GetAll()).Returns(new VoteRepository(voteContext).GetAll());
      this.voteService = new VoteService(voteMock.Object);

    }

    [Test]
    public void GetRoomInfoTest()
    {
      var roomId = TestData.GetTestRoom().Id;
      var userId = TestData.GetTestUser().Id;
      var discusId = TestData.GetTestDiscussion().Id;

      this.roomService.AddUser(roomId, userId);
      var room = this.roomService.GetRoom(roomId);
      var discussions = this.discussionService.GetDiscussions(room.Id);
      this.discussionService.AddVote(discusId, TestData.GetTestVote());

      var users =  this.userService.GetUsers().Where(user => room.Users.Contains(user)).Select(user =>
      new UserDTO()
      {
        Id = user.Id,
        Name = user.Name
      }).ToList();

      var votes = this.voteService.GetVotes(discusId).Select(vote =>
      new VoteDTO()
      {
        Id = vote.Id,
        Card = this.cardService.GetCard(vote.CardId),
        RoomId = vote.RoomId,
        UserId = vote.UserId,
        DiscussionId = vote.DiscussionId
      }).ToList();

      var discussionsInRoom = discussions.Select(discussion =>
      new DiscussionDTO()
      {
        Id = discussion.Id,
        Title = discussion.Title,
        RoomID = discussion.RoomId,
        Start = discussion.Start,
        End = discussion.End,
        Votes = votes,
        AverageVote = this.discussionService.CalculateAverageVote(discussion.Id)
      }).ToList().Where(discussion => discussion.RoomID == room.Id);

      var expected = new RoomDTO()
      {
        Id = room.Id,
        Title = room.Title,
        OwnerId = room.OwnerId,
        Users = users,
        Discussions = discussionsInRoom
      };

      var roomController = new RoomController(this.roomService, this.discussionService, this.cardService);
      var actual = roomController.GetRoomInfo(roomId);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

  }
}
