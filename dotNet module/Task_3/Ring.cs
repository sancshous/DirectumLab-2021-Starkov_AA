using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// <para></para>
  /// </summary>
  public class Ring : Circle
  {
    /// <summary>
    /// радиус внешней окружности
    /// </summary>
    public double OutRadius { get; set; }

    /// <summary>
    /// Кольцо можно объявить в виде 3 точек:
    /// центральной точки, любой точки на внешней окружности и любой точки на внутренней окружности
    /// </summary>
    public Ring(int x, int y, int x1, int y1, int x2, int y2) : base(x, y, x1, y1)
    {
      this.Radius = Dist(x, y, x1, y1);
      this.OutRadius = Dist(x, y, x2, y2);
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override double Perimeter
    {
      get 
      {
        return 2 * Math.PI * (this.OutRadius + this.Radius);
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
        return Math.PI * (Math.Pow(this.OutRadius, 2) - Math.Pow(this.Radius, 2)); 
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
      return "Кольцо с внутренним радиусом " + this.Radius + "и внешним радиусом " + this.OutRadius;
    }
  }
}
