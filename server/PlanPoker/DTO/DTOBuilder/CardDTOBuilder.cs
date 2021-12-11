using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class CardDTOBuilder
  {
    public static CardDTO Build(Card card)
    {
      return new CardDTO()
      {
        Id = card.Id,
        Value = card.Value,
        Title = card.Title
      };
    }

    public static IEnumerable<CardDTO> BuildList(IEnumerable<Card> cards)
    {
      return cards.Select(card => CardDTOBuilder.Build(card));
    }
  }
}
