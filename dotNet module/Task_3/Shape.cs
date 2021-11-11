using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// Фигура.
  /// </summary>
  public abstract class Shape
  {
    /// <summary>
    /// Координата X.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Координата Y.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Периметр.
    /// </summary>
    public abstract double Perimeter { get; }

    /// <summary>
    /// Площадь.
    /// </summary>
    public abstract double Area { get; }

    /// <summary>
    /// Расстояние между двух точек.
    /// </summary>
    public static double Dist(int x, int y, int x1, int y1)
    {
      return Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Shape(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }
  }
}
