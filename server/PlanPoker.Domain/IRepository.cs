using System;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Domain.Repositories
{
  public interface IRepository<T> where T : IEntity
  {
    public void Add(T element);

    public void Save();

    public T Get(Guid id);

    public IQueryable<T> GetAll();

    public void Delete(Guid id);

    public void Delete(T element);
  }
}
