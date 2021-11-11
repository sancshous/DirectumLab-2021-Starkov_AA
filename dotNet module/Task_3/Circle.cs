using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// Окружность.
  /// </summary>
  public class Circle : Shape
  {
    /// <summary>
    /// Radius.
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Окружность можно объявить в виде центральной точки и любой точки на окружности.
    /// </summary>
    public Circle(int x, int y, int x1, int y1) : base(x, y)
    {
      this.Radius = Shape.Distance(x, y, x1, y1);
    }

    /// <inheritdoc/>
    public override double Perimeter => 2 * Math.PI * this.Radius;

    /// <inheritdoc/>
    public override double Area => 0;

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Окружность радиусом " + this.Radius;
    }
  }
}
