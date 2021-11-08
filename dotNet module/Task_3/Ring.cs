using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  class Ring : Circle
  {
    public double OutRadius { get; set; } //радиус внешней окружности
    public double InRadius { get; set; } //радиус внутренней окружности

    //Кольцо можно объявить в виде 3 точек:
    //центральной точки, любой точки на внешней окружности и любой точки на внутренней окружности
    public Ring(int x, int y, int x1, int y1, int x2, int y2) : base(x, y, x1, y1)
    {
      InRadius = Dist(x, y, x1, y1);
      OutRadius = Dist(x, y, x2, y2);
    }

    public override double Perimeter()
    {
      return 2 * Math.PI * (OutRadius + InRadius);
    }

    public override double Area()
    {
      return Math.PI * (Math.Pow(OutRadius, 2) - Math.Pow(InRadius, 2));
    }

    public override void Display()
    {
      Console.WriteLine($"Кольцо с внутренним радиусом {InRadius} и внешним радиусом {OutRadius}");
    }
  }
}
