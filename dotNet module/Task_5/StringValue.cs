using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
  /// <summary>
  /// StringValu.
  /// </summary>
  public class StringValue
  {
    /// <summary>
    /// Value.
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// StringValue.
    /// </summary>
    /// <param name="value">Value.</param>
    public StringValue(string value)
    {
      this.Value = value;
    }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
      return obj is StringValue value &&
             this.Value == value.Value;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
      return HashCode.Combine(this.Value);
    }

    /// <summary>
    /// Оператор сравнения обьектов класса StringValue.
    /// </summary>
    /// <param name="left">Обьект слева от равенства.</param>
    /// <param name="right">Обьект справа от равенства.</param>
    /// <returns>Возвращает true, если обьекты равны.</returns>
    public static bool operator ==(StringValue left, StringValue right)
    {
      return EqualityComparer<StringValue>.Default.Equals(left, right);
    }

    /// <summary>
    /// Оператор неравенства обьектов класса StringValue.
    /// </summary>
    /// <param name="left">Обьект слева от равенства.</param>
    /// <param name="right">Обьект справа от равенства.</param>
    /// <returns>Возвращает true, если обьекты не равны.</returns>
    public static bool operator !=(StringValue left, StringValue right)
    {
      return !(left == right);
    }
  }
}
