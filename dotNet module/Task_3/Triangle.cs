using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// Треугольник.
  /// </summary>
  public class Triangle : Shape
  {
    /// <summary>
    /// FirstSide.
    /// </summary>
    public double FirstSide { get; set; }

    /// <summary>
    /// SecondSide.
    /// </summary>
    public double SecondSide { get; set; }

    /// <summary>
    /// ThirdSide.
    /// </summary>
    public double ThirdSide { get; set; }

    /// <summary>
    /// Треугольник можно объявить в виде 3 точек.
    /// </summary>
    public Triangle(int x, int y, int x1, int y1, int x2, int y2) : base(x, y)
    {
      this.FirstSide = Shape.Distance(x, y, x1, y1);
      this.SecondSide = Shape.Distance(x1, y1, x2, y2);
      this.ThirdSide = Shape.Distance(x, y, x2, y2);
    }

    /// <inheritdoc/>
    public override double Perimeter => this.FirstSide + this.SecondSide + this.ThirdSide;

    /// <inheritdoc/>
    public override double Area
    {
      get
      {
        double p = (this.FirstSide + this.SecondSide + this.ThirdSide) / 2;
        return Math.Sqrt(p * (p - this.FirstSide) * (p - this.SecondSide) * (p - this.ThirdSide));
      }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
      return "Треугольник со сторонами: " + this.FirstSide + this.SecondSide + this.ThirdSide;
    }
  }
}
