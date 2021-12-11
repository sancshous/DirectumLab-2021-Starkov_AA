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

    public RoomService(IRepository<Room> repository)
    {
      this.repository = repository;
    }

    public Room Create(string title, Guid ownerId)
    {
      var id = Guid.NewGuid();
      var room = new Room(id, title, ownerId);
      this.repository.Create(room);
      this.AddUser(id, ownerId);
      this.repository.Save();
      return this.repository.Get(id);
    }

    public void Delete(Guid roomId)
    {
      this.repository.Delete(roomId);
    }

    public void AddUser(Guid roomId, Guid userId)
    {
      this.repository.Get(roomId).Users.Add(userId);
    }

    public void RemoveUser(Guid roomId, Guid userId)
    {
      this.repository.Get(roomId).Users.Remove(userId);
    }

    public ICollection<Guid> GetUsers(Guid roomId)
    {
      return this.repository.Get(roomId).Users;
    }

    public IQueryable<Room> GetRooms()
    {
      return this.repository.GetAll();
    }
  }
}
