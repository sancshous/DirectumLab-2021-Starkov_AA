using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Карта колоды(Числа Фиббоначи).
  /// </summary>
  public class Card : Entity
  {
    /// <summary>
    /// Значение карты.
    /// </summary>
    public int? Value { get; set; }

    /// <summary>
    /// Нечисловое значение карты. Например: "?".
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id карты.</param>
    /// <param name="value">Значение карты.</param>
    /// <param name="title">Нечисловове значение карты.</param>
    public Card(Guid id, int? @value, string title)
    {
      this.Id = id;
      this.Value = @value;
      this.Title = title;
    }
  }
}
