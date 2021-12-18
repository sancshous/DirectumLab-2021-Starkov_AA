using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;
using System.Linq;

namespace PlanPoker.Infrastructure.Repositories
{
  public class RoomRepository : BaseRepository<Room>
  {
    public RoomRepository(RoomContext context) : base(context)
    {
    }

    public override IQueryable<Room> GetAll()
    {
      return this.Context.Elements.Include(room => room.Users);
    }
  }
}
