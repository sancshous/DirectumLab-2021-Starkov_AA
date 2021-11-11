using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// Прямоугольник.
  /// </summary>
  public class Rectangle : Shape
  {
    /// <summary>
    /// Ширина.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Длина.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Прямоугольник можно объявить в виде 2 точек: начальная точка диагонали и конечная точка диагонали.
    /// </summary>
    public Rectangle(int x, int y, int x1, int y1) : base(x, y)
    {
      this.Width = Shape.Distance(x, y, x1, y);
      this.Height = Shape.Distance(x, y, x, y1);
    }

    /// <inheritdoc/>
    public override double Perimeter => this.Width * 2 + this.Height * 2;

    /// <inheritdoc/>
    public override double Area => this.Width * this.Height;

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Прямоугольник с длиной " + this.Height + " и шириной " + this.Width;
    }
  }
}
