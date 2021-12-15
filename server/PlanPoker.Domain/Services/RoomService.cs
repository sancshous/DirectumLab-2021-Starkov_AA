using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.Domain.Services
{
  public class RoomService
  {
    private readonly IRepository<Room> repository;

    private readonly IRepository<User> userRepository;

    public RoomService(IRepository<Room> repository, IRepository<User> userRepository)
    {
      this.repository = repository;
      this.userRepository = userRepository;
    }

    public Room Create(string title, Guid ownerId)
    {
      var id = Guid.NewGuid();
      var room = new Room(id, title, ownerId);
      this.repository.Add(room);
      this.AddUser(id, ownerId);
      this.repository.Save();
      return room;
    }

    public void Delete(Guid roomId)
    {
      this.repository.Delete(roomId);
    }

    public User GetUser(Guid id)
    {
      return this.userRepository.Get(id);
    }

    public void AddUser(Guid roomId, Guid userId)
    {
      var user = this.GetUser(userId);
      this.repository.Get(roomId).Users.Add(user);
    }

    public void RemoveUser(Guid roomId, User user)
    {
      this.repository.Get(roomId).Users.Remove(user);
    }

    public ICollection<User> GetUsers(Guid roomId)
    {
      return this.repository.Get(roomId).Users;
    }

    public Room GetRoom(Guid id)
    {
      return this.repository.Get(id);
    }

    public IEnumerable<Room> GetRooms()
    {
      return this.repository.GetAll();
    }
  }
}
