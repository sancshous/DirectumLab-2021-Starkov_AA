using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using PlanPoker.Infrastructure.Contexts;
using PlanPoker.Infrastructure.Repositories;

namespace PlanPoker
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var mvcBuilder = services.AddControllers();

      mvcBuilder.Services.Configure((MvcOptions options) =>
      {
        options.Filters.Add<ExceptionFilter>();
      });

      services
        .AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("Users"))
        .AddTransient<IRepository<User>, UserRepository>()
        .AddTransient<UserService>()

        .AddDbContext<CardContext>(opt => opt.UseInMemoryDatabase("Cards"))
        .AddTransient<IRepository<Card>, CardRepository>()
        .AddTransient<CardService>()

        .AddDbContext<RoomContext>(opt => opt.UseInMemoryDatabase("Rooms"))
        .AddTransient<IRepository<Room>, RoomRepository>()
        .AddTransient<RoomService>()

        .AddEntityFrameworkInMemoryDatabase();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
