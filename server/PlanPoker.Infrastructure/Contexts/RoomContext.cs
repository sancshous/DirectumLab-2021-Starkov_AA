using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class RoomContext : ApiContext<Room>
  {
    public RoomContext(DbContextOptions<RoomContext> options) : base(options)
    {
    }
  }
}
