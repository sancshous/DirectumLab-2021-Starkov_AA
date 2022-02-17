using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanPoker.Domain.Entities
{
  public abstract class Entity : IEntity
  {
    /// <summary>
    /// Id сущности.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    public Entity(Guid id)
    {
      this.Id = id;
    }
  }
}
