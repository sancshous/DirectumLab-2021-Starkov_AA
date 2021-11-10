using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// <para></para>
  /// </summary>
  public class Triangle : Shape
  {
    /// <summary>
    /// <para></para>
    /// </summary>
    public double FirstSide { get; set; }

    /// <summary>
    /// <para></para>
    /// </summary>
    public double SecondSide { get; set; }

    /// <summary>
    /// <para></para>
    /// </summary>
    public double ThirdSide { get; set; }

    /// <summary>
    /// Треугольник можно объявить в виде 3 точек
    /// </summary>
    public Triangle(int x, int y, int x1, int y1, int x2, int y2) : base(x, y)
    {
      this.FirstSide = Dist(x, y, x1, y1);
      this.SecondSide = Dist(x1, y1, x2, y2);
      this.ThirdSide = Dist(x, y, x2, y2);
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override double Perimeter
    {
      get 
      {
        return this.FirstSide + this.SecondSide + this.ThirdSide;
      }

      set
      {
        this.Perimeter = value; 
      }
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override double Area
    {
      get
      {
        double p = (this.FirstSide + this.SecondSide + this.ThirdSide) / 2;
        return Math.Sqrt(p * (p - this.FirstSide) * (p - this.SecondSide) * (p - this.ThirdSide));
      }

      set 
      {
        this.Area = value; 
      }
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override string ToString()
    {
      return "Треугольник со сторонами: " + this.FirstSide + this.SecondSide + this.ThirdSide;
    }
  }
}
