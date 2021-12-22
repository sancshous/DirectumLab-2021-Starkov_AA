using PlanPoker.Domain.Entities;
using System;

namespace Tests
{
  public static class TestData
  {
    public static Discussion GetTestDiscussion()
    {
      string stringGuidId = "a2e3c535-d09f-4a22-b17a-c91b2f6a155a";
      var roomId = GetTestRoom().Id;
      return new Discussion(Guid.Parse(stringGuidId), roomId, "TestDiscussion");
    }

    public static User GetTestUser()
    {
      string stringGuidId = "25e9d884-c5f8-4b34-ac7f-e72771a2a956";
      return new User(Guid.Parse(stringGuidId), "TestOwner", stringGuidId);
    }

    public static Room GetTestRoom()
    {
      string stringGuidId = "618e416d-4148-4d68-9bac-97343fd8ca30";
      var userId = GetTestUser().Id;
      var room = new Room(Guid.Parse(stringGuidId), "TestRoom", userId);
      return room;
    }

    public static Card GetTestCard()
    {
      string stringGuidId = "1036daf7-7817-4257-988e-99f7243064fd";
      return new Card(Guid.Parse(stringGuidId), 5, "five");
    }

    public static Vote GetTestVote()
    {
      var userId = GetTestUser().Id;
      var cardId = GetTestCard().Id;
      var roomId = GetTestRoom().Id;
      var discussionId = GetTestDiscussion().Id;
      string stringGuidId = "e89de7d7-d3f2-4310-9347-fb3b7cfac374";
      return new Vote(Guid.Parse(stringGuidId), cardId, roomId, userId, discussionId);
    }
  }
}
