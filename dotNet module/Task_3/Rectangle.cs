using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  class Rectangle : Square
  {
    public double Width { get; set; }
    public double Height { get; set; }

    //Прямоугольник можно объявить в виде 3 точек:
    //начальная "угловая точка" являющаяся началом длины и ширины, конечная точка длины, конечная точка ширины
    public Rectangle(int x, int y, int x1, int y1, int x2, int y2) : base(x, y, x1, y1)
    {
      Width = Dist(x, y, x1, y1);
      Height = Dist(x, y, x2, y2);
    }

    public override double Perimeter()
    {
      return Width * 2 + Height * 2;
    }
    public override double Area()
    {
      return Width * Height;
    }
    public override void Display()
    {
      Console.WriteLine($"Прямоугольник с длиной {Height} и шириной {Width}");
    }
  }
}
