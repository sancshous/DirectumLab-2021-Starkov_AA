using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class BaseRepository<T> : IRepository<T>, IDisposable where T : class, IEntity
  {
    protected ApiContext<T> context { get; set; }

    private bool disposed = false;

    public BaseRepository(ApiContext<T> context)
    {
      this.context = context;
    }

    public void Add(T element)
    {
      this.context.Elements.Add(element);
      this.context.SaveChanges();
    }

    public void Save()
    {
      this.context.SaveChanges();
    }

    public T Get(Guid id)
    {
      return this.context.Elements.Find(id);
    }

    public IQueryable<T> GetAll()
    {
      return this.context.Elements;
    }

    public void Delete(Guid id)
    {
      T element = this.context.Elements.Find(id);
      this.context.Elements.Remove(element);
      this.context.SaveChanges();
    }

    public void Delete(T element)
    {
      if (this.context.Elements.Any(o => o.Id == element.Id))
        this.context.Elements.Remove(element);
      this.context.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
          this.context.Dispose();
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
