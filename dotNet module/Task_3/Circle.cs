using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
  class Circle : Shape
  {
    public double Radius { get; set; }

    //Окружность можно объявить в виде центральной точки и любой точки на окружности (таким образом находим радиус)
    public Circle(int x, int y, int x1, int y1) : base(x, y)
    {
      Radius = Dist(x, y, x1, y1);
    }

    public override double Perimeter() //длина окружности
    {
      return 2 * Math.PI * Radius;
    }

    public override double Area() // у окружности нет площади
    {
      throw new NotImplementedException();
    }

    public override void Display()
    {
      Console.WriteLine($"Окружность радиусом {Radius}"); 
    }
  }
}
