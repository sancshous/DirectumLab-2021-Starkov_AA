using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class RoomService
  {
    private readonly IRepository<Room> roomRepository;

    private readonly IRepository<User> userRepository;

    private readonly IRepository<Discussion> discussionRepository;

    public RoomService(IRepository<Room> repository, IRepository<User> userRepository, IRepository<Discussion> discussionRepository)
    {
      this.roomRepository = repository;
      this.userRepository = userRepository;
      this.discussionRepository = discussionRepository;
    }

    public Room Create(string title, Guid ownerId)
    {
      var id = Guid.NewGuid();
      var room = new Room(id, title, ownerId);
      this.roomRepository.Add(room);
      this.AddUser(id, ownerId);
      return room;
    }

    public void Delete(Guid roomId)
    {
      this.roomRepository.Delete(roomId);
      this.roomRepository.Save();
    }

    public User GetUser(Guid id)
    {
      return this.userRepository.Get(id);
    }

    public User SearchUser(Guid userId, Guid roomId)
    {
      var room = this.roomRepository.Get(roomId);
      User user = null;
      foreach (var item in room.Users)
      {
        if (item.Id == userId)
        {
          user = item;
        }
      }
      return user;
    }

    public Room SearchRoom(Guid roomId)
    {
      Room room = null;
      foreach (var item in this.roomRepository.GetAll())
      {
        if (item.Id == roomId)
        {
          room = item;
        }
      }
      return room;
    }

    public void AddUser(Guid roomId, Guid userId)
    {
      var user = this.GetUser(userId);
      this.roomRepository.Get(roomId).Users.Add(user);
      this.roomRepository.Save();
    }

    public void RemoveUser(Guid roomId, Guid userId)
    {
      var user = this.GetUser(userId);
      this.roomRepository.Get(roomId).Users.Remove(user);
      this.roomRepository.Save();
    }

    public void DeleteDiscussion(Guid roomId, Guid discussionId)
    {
      var discussion = this.discussionRepository.Get(discussionId);
      this.roomRepository.GetAll().First(r => r.Id == roomId).Discussions.Remove(discussion);
      this.roomRepository.Save();
    }

    public ICollection<User> GetUsers(Guid roomId)
    {
      return this.roomRepository.Get(roomId).Users;
    }

    public Room GetRoom(Guid roomId)
    { 
      return this.roomRepository.Get(roomId);
    }

    public IEnumerable<Room> GetRooms()
    {
      return this.roomRepository.GetAll();
    }
  }
}
