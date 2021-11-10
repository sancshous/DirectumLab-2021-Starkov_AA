using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// <para></para>
  /// </summary>
  public class Circle : Shape
  {
    /// <summary>
    /// <para></para>
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Окружность можно объявить в виде центральной точки и любой точки на окружности (таким образом находим радиус)
    /// </summary>
    public Circle(int x, int y, int x1, int y1) : base(x, y)
    {
      this.Radius = Dist(x, y, x1, y1);
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override double Perimeter //длина окружности
    {
      get
      {
        return 2 * Math.PI * this.Radius;
      }

      set
      {
        this.Perimeter = value; 
      }
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override double Area // у окружности нет площади
    {
      get 
      {
        return 0; 
      }

      set { }
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override string ToString()
    {
      return "Окружность радиусом " + this.Radius;
    }
  }
}
