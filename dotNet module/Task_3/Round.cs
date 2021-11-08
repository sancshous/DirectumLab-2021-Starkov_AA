using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  class Round : Circle
  {
    public double Radius { get; set; }

    //Круг это окружность с внутренней площадью, поэтому метод длины окружности не нужно переопределять
    public Round(int x, int y, int x1, int y1) : base(x, y, x1, y1)
    {
      Radius = Dist(x, y, x1, y1);
    }

    public override double Area() 
    {
      return Math.PI * Math.Pow(Radius, 2);
    }

    public override void Display()
    {
      Console.WriteLine($"Круг радиусом {Radius}");
    }
  }
}
