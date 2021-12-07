using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanPoker.Domain.Entities
{
  public class Entity : IEntity
  {
    /// <summary>
    /// Id карты.
    /// </summary>
    public Guid Id { get; set; }
  }
}
