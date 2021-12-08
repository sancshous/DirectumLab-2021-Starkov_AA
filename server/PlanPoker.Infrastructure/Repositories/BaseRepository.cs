using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class BaseRepository<T> : IRepository<T>, IDisposable where T : class, IEntity
  {
    public ApiContext<T> Db { get; set; }

    private bool disposed = false;

    public BaseRepository(ApiContext<T> context)
    {
      this.Db = context;
    }

    public void Save(T element)
    {
      this.Db.Elements.Add(element);
      this.Db.SaveChanges();
    }

    public T Get(Guid id)
    {
      return this.Db.Elements.Find(id);
    }

    public IQueryable<T> GetAll()
    {
      return this.Db.Elements;
    }

    public void Delete(Guid id)
    {
      T element = this.Db.Elements.Find(id);
      this.Db.Elements.Remove(element);
      this.Db.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
          this.Db.Dispose();
      }

      this.disposed = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
