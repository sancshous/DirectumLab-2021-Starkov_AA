using System;
namespace Task_3
{
  /// <summary>
  /// <para></para>
  /// </summary>
  public class Program
  {
    /// <summary>
    /// <para></para>
    /// </summary>
    public static void Main(string[] args)
    {
      var circle = new Circle(1, 1, 4, 4);
      Console.WriteLine(circle.ToString());
      Console.WriteLine($"Длина окружности = {circle.Perimeter}\n");

      var round = new Round(2, 2, 4, 4);
      Console.WriteLine(round.ToString());
      Console.WriteLine($"Длина окружности(круга) = {round.Perimeter}\nПлощадь круга = {round.Area}\n");

      var square = new Square(1, 1, 5, 5);
      Console.WriteLine(square.ToString());
      Console.WriteLine($"Периметр квадрата = {square.Perimeter}\nПлощадь квадрата = {square.Area}\n");

      var rectangle = new Rectangle(2, 2, 4, 4);
      Console.WriteLine(rectangle.ToString());
      Console.WriteLine($"Периметр прямоугольника = {rectangle.Perimeter}\nПлощадь прямоугольника = {rectangle.Area}\n");

      var tryangle = new Triangle(1, 1, 2, 2, 7, 7);
      Console.WriteLine(tryangle.ToString());
      Console.WriteLine($"Периметр треугольника = {tryangle.Perimeter}\nПлощадь треугольника = {tryangle.Area}\n");

      var ring = new Ring(1, 1, 2, 2, 7, 7);
      Console.WriteLine(ring.ToString());
      Console.WriteLine($"Периметр кольца = {ring.Perimeter}\nПлощадь кольца = {ring.Area}\n");
    }
  }
}
