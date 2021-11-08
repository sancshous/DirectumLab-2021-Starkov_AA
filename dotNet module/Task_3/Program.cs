using System;
namespace Task_3
{
  class Program
  {
    static void Main(string[] args)
    {
      var circle = new Circle(1, 1, 4, 4);
      circle.Display();
      Console.WriteLine($"Длина окружности = {circle.Perimeter()}\n");

      var round = new Round(2, 2, 4, 4);
      round.Display();
      Console.WriteLine($"Длина окружности(круга) = {round.Perimeter()}\nПлощадь круга = {round.Area()}\n");

      var square = new Square(1, 1, 5, 5);
      square.Display();
      Console.WriteLine($"Периметр квадрата = {square.Perimeter()}\nПлощадь квадрата = {square.Area()}\n");

      var rectangle = new Rectangle(1, 1, 2, 2, 7, 7);
      rectangle.Display();
      Console.WriteLine($"Периметр прямоугольника = {rectangle.Perimeter()}\nПлощадь прямоугольника = {rectangle.Area()}\n");

      var tryangle = new Triangle(1, 1, 2, 2, 7, 7);
      tryangle.Display();
      Console.WriteLine($"Периметр треугольника = {tryangle.Perimeter()}\nПлощадь треугольника = {tryangle.Area()}\n");

      var ring = new Ring(1, 1, 2, 2, 7, 7);
      ring.Display();
      Console.WriteLine($"Периметр кольца = {ring.Perimeter()}\nПлощадь кольца = {ring.Area()}\n");
    }
  }
}
