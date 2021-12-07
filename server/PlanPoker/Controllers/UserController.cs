using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.DTOBuilder;
using PlanPoker.Services;

namespace PlanPoker.Controllers
{
  [ApiController]
  [Route("/api/[controller]/[action]")]
  public class UserController : ControllerBase
  {
    private readonly UserService service;

    public UserController(UserService service)
    {
      this.service = service;
    }

    [HttpGet]
    public UserDTO Create(string name)
    {
      var player = this.service.Create(name);
      return UserDTOBuilder.Build(player);
    }

    [HttpGet]
    public IEnumerable<UserDTO> GetPlayers()
    {
      var players = this.service.GetPlayers();
      return UserDTOBuilder.BuildList(players);
    }
  }
}
