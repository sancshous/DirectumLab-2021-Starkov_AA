using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Task_12
{
  public static class AssemblyTools
  {
    /// <summary>
    /// Возвращает имена всех read-write свойств объекта и строковые представления значений свойств.
    /// </summary>
    /// <param name="object">Object.</param>
    public static string ShowAllReadWriteProperties(object @object)
    {
      var type = @object.GetType();
      var sb = new StringBuilder();
      foreach (PropertyInfo property in type.GetProperties())
      {
        if (property.CanRead && property.CanWrite)
          sb.AppendLine($"{property.PropertyType} {property.Name} {property.GetValue(@object)}");
      }
      return sb.ToString();
    }

    /// <summary>
    /// Показывает имена всех read-write свойств объекта и строковые представления значений свойств, принимая на вход имя сборки и имя класса.
    /// </summary>
    /// <param name="assemblyPath">Имя сборки.</param>
    /// <param name="className">Имя класса.</param>
    public static string ShowAllReadWriteProperties(string assemblyPath, string className)
    {
      var myAssembly = Assembly.LoadFrom(assemblyPath);
      var myClass = myAssembly.GetType(className);
      object obj = Activator.CreateInstance(myClass);

      return ShowAllReadWriteProperties(obj);
    }

    /// <summary>
    /// Показывает имена всех read-write свойств объекта, исключая свойства помеченные атрибутом Obsolete, принимая на вход имя сборки и имя класса.
    /// </summary>
    /// <param name="assemblyPath">Имя сборки.</param>
    /// <param name="className">Имя класса.</param>
    public static string ShowNewestProperties(string assemblyPath, string className)
    {
      var myAssembly = Assembly.LoadFrom(assemblyPath);
      var myClass = myAssembly.GetType(className);
      object obj = Activator.CreateInstance(myClass);
      var sb = new StringBuilder();

      foreach (var property in obj.GetType().GetProperties())
      {
        if (property.CanRead && property.CanWrite)
        {
          var attributes = property.GetCustomAttributes(true);
          var isObsolete = attributes
            .Where(attribute => attribute is ObsoleteAttribute)
            .Any();
          if (!isObsolete)
          {
            sb.AppendLine($"{property.PropertyType} {property.Name} {property.GetValue(obj)}");
          }
        }
      }
      return sb.ToString();
    }

  }
}
