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
    public double? Value { get; set; }

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
    public Card(Guid id, double? @value, string title) : base(id)
    {
      this.Value = @value;
      this.Title = title;
    }
  }
}
