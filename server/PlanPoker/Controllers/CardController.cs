using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
using PlanPoker.DTO.DTOBuilder;
using System.Collections.Generic;

namespace PlanPoker.Controllers
{
  [ApiController]
  [Route("/api/[controller]/[action]")]
  public class CardController // Пока использую для теста, потом удалю контролер
  {
    private readonly CardService service;

    public CardController(CardService service)
    {
      this.service = service;
    }

    [HttpGet]
    public IEnumerable<CardDTO> GetCards()
    {
      var cards = this.service.GetCards();
      return CardDTOBuilder.BuildList(cards);
    }
  }
}
