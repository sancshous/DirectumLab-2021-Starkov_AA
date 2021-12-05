using System;
using System.Linq;
using PlanPoker.Domain.Contexts;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  public class BaseRepository<T> : IRepository<T> where T : class, IEntity
  {
    public ApiContext<T> Db { get; set; }

    public BaseRepository(ApiContext<T> context)
    {
      this.Db = context;
    }

    public void Save(T element)
    {
      this.Db.Elements.Add(element);
      this.Db.SaveChanges();
    }

    public T Get(Guid id) => this.Db.Elements.Find(id);

    public IQueryable<T> GetAll() => this.Db.Elements;

    public void Delete(Guid id)
    {
      T element = this.Db.Elements.Find(id);
      this.Db.Elements.Remove(element);
      this.Db.SaveChanges();
    }
  }
}
