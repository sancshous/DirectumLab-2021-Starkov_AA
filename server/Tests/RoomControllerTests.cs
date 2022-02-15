using Moq;
using NUnit.Framework;
using PlanPoker.Controllers;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
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
      var discussionContext = new TestContext().DiscussionContext;
      var cardContext = new TestContext().CardContext;
      var voteContext = new TestContext().VoteContext;

      this.userService = new UserService(new UserRepository(userContext));
      this.roomService = new RoomService(new RoomRepository(roomContext), new UserRepository(userContext));
      this.cardService = new CardService(new CardRepository(cardContext));
      this.voteService = new VoteService(new VoteRepository(voteContext));
      this.discussionService = new DiscussionService(new DiscussionRepository(discussionContext), new CardRepository(cardContext));
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
        UserId = vote.UserId,
        //DiscussionId = vote.DiscussionId
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
        //Discussions = discussionsInRoom
      };

      var roomController = new RoomController(this.roomService, this.discussionService, this.cardService);
      var actual = roomController.GetRoomInfo(roomId);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

  }
}
