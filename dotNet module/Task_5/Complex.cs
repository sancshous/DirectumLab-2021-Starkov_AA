using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Task_5
{
  /// <summary>
  /// Определение комплексного числа.
  /// </summary>
  public class Complex : IComparable, IComparable<Complex>
  {
    /// <summary>
    /// Определение вещественной части комплексного числа.
    /// </summary>
    public int Re { get; set; }

    /// <summary>
    /// Определение мнимой части комплексного числа.
    /// </summary>
    public int Im { get; set; }

    /// <summary>
    /// Модуль комплексного числа.
    /// </summary>
    /// <returns>Возвращает модуль комплексного числа.</returns>
    public int Module() => (int)Math.Sqrt(Math.Pow(this.Re, 2) + Math.Pow(this.Im, 2));

    /// <inheritdoc/>
    public int CompareTo(object obj)
    {
      if (obj is null) 
        return 1;
      if (obj is Complex otherComplex)
        return this.Module().CompareTo(otherComplex.Module());
      else
        throw new ArgumentException("Object is not a Complex");
    }

    /// <inheritdoc/>
    public int CompareTo([AllowNull] Complex other)
    {
      if (other is null)
        return 1;
      return this.Module().CompareTo(other.Module());
    }

    /// <inheritdoc/>
    public override string ToString()
    {
      return $"{this.Re} + {this.Im}i ";
    }
  }
}