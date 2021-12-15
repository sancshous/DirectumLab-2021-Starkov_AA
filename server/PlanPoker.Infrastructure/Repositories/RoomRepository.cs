using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class RoomRepository : BaseRepository<Room>
  {
    public RoomRepository(RoomContext context) : base(context)
    {
      context.Elements.Include(room => room.Users);
      this.Save();
    }
  }
}
