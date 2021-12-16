using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class CardDTOBuilder
  {
    public static IEnumerable<CardDTO> BuildList(IEnumerable<Card> cards)
    {
      CardDTO Build(Card card)
      {
        return new CardDTO()
        {
          Id = card.Id,
          Value = card.Value,
          Title = card.Title
        };
      }
      return cards.Select(card => Build(card));
    }
  }
}
