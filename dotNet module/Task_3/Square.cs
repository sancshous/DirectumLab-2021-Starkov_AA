using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// Квадрат.
  /// </summary>
  public class Square : Rectangle
  {
    /// <summary>
    /// Квадрат можно объявить в виде начальной и конечной точки стороны.
    /// </summary>
    public Square(int x, int y, int x1, int y1) : base(x, y, x1, y1)
    {
    }

    /// <inheritdoc/>
    public override double Perimeter => this.Width * 4;

    /// <inheritdoc/>
    public override double Area => this.Width * this.Width;

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Квадрат со стороной " + this.Width;
    }
  }
}
