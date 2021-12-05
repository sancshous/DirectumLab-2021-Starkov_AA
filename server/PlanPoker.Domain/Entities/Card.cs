using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Карта колоды(Числа Фиббоначи).
  /// </summary>
  public class Card : IEntity
  {
    /// <summary>
    /// Id карты.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Значение карты.
    /// </summary>
    public int? Value { get; set; }

    /// <summary>
    /// Нечисловое значение карты. Например: "?".
    /// </summary>
    public string NotNumeric { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id карты.</param>
    /// <param name="value">Значение карты.</param>
    public Card(Guid id, int? @value, string notNumeric)
    {
      this.Id = id;
      this.Value = @value;
      this.NotNumeric = notNumeric;
    }
  }
}
