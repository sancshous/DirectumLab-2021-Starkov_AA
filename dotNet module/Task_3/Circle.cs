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
    /// Окружность можно объявить в виде центральной точки и любой точки на окружности (таким образом находим радиус).
    /// </summary>
    public Circle(int x, int y, int x1, int y1) : base(x, y)
    {
      this.Radius = Dist(x, y, x1, y1);
    }

    /// <summary>
    /// Длина окружности.
    /// </summary>
    public override double Perimeter => 2 * Math.PI * this.Radius;

    /// <summary>
    /// У окружности нет площади.
    /// </summary>
    public override double Area => 0;

    /// <summary>
    /// ToString.
    /// </summary>
    public override string ToString()
    {
      return "Окружность радиусом " + this.Radius;
    }
  }
}
