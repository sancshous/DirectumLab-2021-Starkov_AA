using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  class Square : Shape
  {
    public double Width { get; set; }
    //Квадрат можно объявить в виде начальной и конечной точки стороны
    public Square(int x, int y, int x1, int y1) : base(x, y)
    {
      Width = Dist(x, y, x1, y1);
    }

    public override double Perimeter()
    {
      return Width * 4;
    }
    public override double Area()
    {
      return Width * Width;
    }
    public override void Display()
    {
      Console.WriteLine($"Квадрат со стороной {Width}");
    }
  }
}
