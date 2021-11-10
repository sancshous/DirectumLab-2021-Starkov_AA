using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// <para></para>
  /// </summary>
  public abstract class Shape
  {
    /// <summary>
    /// <para></para>
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// <para></para>
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// <para></para>
    /// </summary>
    public abstract double Perimeter { get; set; }

    /// <summary>
    /// <para></para>
    /// </summary>
    public abstract double Area { get; set; }

    /// <summary>
    /// <para></para>
    /// </summary>
    public double Dist(int x, int y, int x1, int y1)
    {
      return Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
    }

    /// <summary>
    /// <param></param>
    /// </summary>
    public Shape(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }
  }
}
