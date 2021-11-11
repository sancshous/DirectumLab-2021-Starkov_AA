using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// Круг.
  /// </summary>
  public class Round : Circle
  {
    /// <summary>
    /// Круг это окружность с внутренней площадью, поэтому метод длины окружности не нужно переопределять.
    /// </summary>
    public Round(int x, int y, int x1, int y1) : base(x, y, x1, y1) { }

    /// <summary>
    /// Площадь.
    /// </summary>
    public override double Area => Math.PI * Math.Pow(this.Radius, 2);

    /// <summary>
    /// ToString.
    /// </summary>
    public override string ToString()
    {
      return "Круг радиусом " + this.Radius;
    }
  }
}
