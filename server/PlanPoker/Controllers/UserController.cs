using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
using PlanPoker.DTO.DTOBuilder;

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
      var user = this.service.Create(name);
      return UserDTOBuilder.Build(user);
    }

    [HttpGet]
    public IEnumerable<UserDTO> GetUsers() // для теста, потом удалю
    {
      var users = this.service.GetUsers();
      return UserDTOBuilder.BuildList(users);
    }
  }
}
