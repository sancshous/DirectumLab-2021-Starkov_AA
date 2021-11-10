using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  /// <summary>
  /// <para></para>
  /// </summary>
  public class Square : Rectangle
  {
    /// <summary>
    /// Квадрат можно объявить в виде начальной и конечной точки стороны
    /// </summary>
    public Square(int x, int y, int x1, int y1) : base(x, y, x1, y1)
    {
      this.Width = Dist(x, y, x, y1);
    }

    /// <summary>
    /// <para></para>
    /// </summary>
    public override double Perimeter
    {
      get 
      {
        return this.Width * 4; 
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
        return this.Width * this.Width; 
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
      return "Квадрат со стороной " + this.Width;
    }
  }
}
