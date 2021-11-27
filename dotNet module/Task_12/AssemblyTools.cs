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
    /// <param name="object">Object.</param>
    public static void ShowAllReadWriteProperties(object @object)
    {
      var type = @object.GetType();
      foreach (PropertyInfo property in type.GetProperties())
      {
        Console.WriteLine($"Свойство: {property.PropertyType} {property.Name}");
        Console.WriteLine($"Гетеры : {property.GetGetMethod()} . Его значение: {property.GetValue(@object)}");
        Console.WriteLine($"Сетеры: {property.GetSetMethod()}\n");
      }
    }

    /// <summary>
    /// Показывает имена всех read-write свойств объекта и строковые представления значений свойств, принимая на вход имя сборки и имя класса.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="className">Имя класса.</param>
    public static void ShowAllReadWriteProperties(string assemblyPath, string className)
    {
      var myAssembly = Assembly.LoadFrom(assemblyPath);
      var myClass = myAssembly.GetType(className);
      object obj = Activator.CreateInstance(myClass);

      ShowAllReadWriteProperties(obj);
    }

    /// <summary>
    /// Показывает имена всех read-write свойств объекта, исключая свойства помеченные атрибутом Obsolete, принимая на вход имя сборки и имя класса.
    /// </summary>
    /// <param name="assemblyPath">Имя сборки.</param>
    /// <param name="className">Имя класса.</param>
    public static void ShowNewestProperties(string assemblyPath, string className)
    {
      var myAssembly = Assembly.LoadFrom(assemblyPath);
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
