using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  abstract class Shape
  {
    public int X { get; set; }
    public int Y { get; set; }
    //public double Dist { get; set; }
    public double Dist(int x, int y, int x1, int y1)
    {
      return Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
    }

    public Shape (int x, int y)
    {
      X = x;
      Y = y;
    }

    public abstract double Perimeter();
    public abstract double Area();
    public abstract void Display();
  }
}
