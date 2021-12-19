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

    public RoomService(IRepository<Room> repository, IRepository<User> userRepository)
    {
      this.roomRepository = repository;
      this.userRepository = userRepository;
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
