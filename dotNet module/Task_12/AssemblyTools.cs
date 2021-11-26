using System;
using System.Linq;
using System.Reflection;

namespace Task_12
{
  public static class AssemblyTools
  {
    /// <summary>
    /// Возвращает имена всех read-write свойств объекта и строковые представления значений свойств.
    /// </summary>
    /// <param name="object1">Object.</param>
    public static void ShowAllReadWriteProperties(object object1)
    {
      var myType = object1.GetType();
      foreach (PropertyInfo property in myType.GetProperties())
      {
        Console.WriteLine($"Свойство: {property.PropertyType} {property.Name}");
        Console.WriteLine($"Гетеры : {property.GetGetMethod()} . Его значение: {property.GetValue(object1)}");
        Console.WriteLine($"Сетеры: {property.GetSetMethod()}\n");
      }
    }

    /// <summary>
    /// Показывает имена всех read-write свойств объекта и строковые представления значений свойств, принимая на вход имя сборки и имя класса.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="className">Имя класса.</param>
    public static void ShowValuesReadProperties(string assemblyName, string className)
    {
      var myAssembly = Assembly.LoadFrom(assemblyName);
      var myClass = myAssembly.GetType(className);
      object obj = Activator.CreateInstance(myClass);

      ShowAllReadWriteProperties(obj);
    }

    /// <summary>
    /// Показывает имена всех read-write свойств объекта, исключая свойства помеченные атрибутом Obsolete, принимая на вход имя сборки и имя класса.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="className">Имя класса.</param>
    public static void ShowNewestProperties(string assemblyName, string className)
    {
      var myAssembly = Assembly.LoadFrom(assemblyName);
      var myClass = myAssembly.GetType(className);
      object obj = Activator.CreateInstance(myClass);

      foreach (var property in obj.GetType().GetProperties())
      {
        var attributes = property.GetCustomAttributes(true);
        var isObsolete = attributes
          .Where(attribute => attribute is ObsoleteAttribute)
          .Any();
        if (!isObsolete)
        {
          Console.WriteLine($"Свойство: {property.PropertyType} {property.Name}");
          Console.WriteLine($"Гетеры : {property.GetGetMethod()} . Его значение: {property.GetValue(obj)}");
          Console.WriteLine($"Сетеры: {property.GetSetMethod()}\n");
        }
      }
    }
  }
}
