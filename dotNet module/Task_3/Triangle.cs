using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  class Triangle : Shape
  {
    public double FirstSide { get; set; }
    public double SecondSide { get; set; }
    public double ThirdSide { get; set; }

    //Треугольник можно объявить в виде 3 точек
    public Triangle(int x, int y, int x1, int y1, int x2, int y2) : base(x, y)
    {
      FirstSide = Dist(x, y, x1, y1);
      SecondSide = Dist(x1, y1, x2, y2);
      ThirdSide = Dist(x, y, x2, y2);
    }

    public override double Perimeter()
    {
      return FirstSide + SecondSide + ThirdSide;
    }
    public override double Area()
    {
      double p = (FirstSide + SecondSide + ThirdSide) / 2;
      return Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));
    }
    public override void Display()
    {
      Console.WriteLine($"Треугольник со сторонами {FirstSide}; {SecondSide}; {ThirdSide}");
    }
  }
}
