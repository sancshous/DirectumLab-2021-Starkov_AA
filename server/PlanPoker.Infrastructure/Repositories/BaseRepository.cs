using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class BaseRepository<T> : IRepository<T>, IDisposable where T : class, IEntity
  {
    protected ApiContext<T> Context { get; set; }

    private bool disposed = false;

    public BaseRepository(ApiContext<T> context)
    {
      this.Context = context;
    }

    public virtual void Add(T element)
    {
      this.Context.Elements.Add(element);
    }

    public virtual void Save()
    {
      this.Context.SaveChanges();
    }

    public virtual T Get(Guid id)
    {
      return this.Context.Elements.Find(id);
    }

    public virtual IQueryable<T> GetAll()
    {
      return this.Context.Elements;
    }

    public virtual void Delete(Guid id)
    {
      T element = this.Context.Elements.Find(id);
      this.Context.Elements.Remove(element);
      this.Context.SaveChanges();
    }

    public virtual void Delete(T element)
    {
      if (this.Context.Elements.Any(o => o.Id == element.Id))
      {
        this.Context.Elements.Remove(element);
        this.Context.SaveChanges();
      }  
    }

    public virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
          this.Context.Dispose();
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
