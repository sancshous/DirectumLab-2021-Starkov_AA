using System;
using System.Configuration;
using System.IO;
using TestAssembly;

namespace Task_12
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // Задание 1.
      Console.WriteLine("Задание 1");
      var testClass = new TestClass();
      AssemblyTools.ShowAllReadWriteProperties(testClass);
      Console.ReadKey();

      // Задание 2.
      Console.WriteLine("Задание 2");
      var assemblyPath = "TestAssembly.dll";
      var className = "TestAssembly.TestClass";
      AssemblyTools.ShowAllReadWriteProperties(assemblyPath, className);
      Console.ReadKey();

      // Задание 3.
      Console.WriteLine("Задание 3");
      AssemblyTools.ShowNewestProperties(assemblyPath, className);
      Console.ReadKey();

      // Задание 4.
      Console.WriteLine("Задание 4");
      Console.WriteLine("Конфиг файл: ");
      var settingSection = ConfigurationManager.GetSection("ProgramSettings") as CustomSection;
      if (settingSection != null)
      {
        Console.WriteLine($"{settingSection.GetType().GetProperties()[0].Name} = {settingSection.IntSetting} {settingSection.GetType().GetProperties()[1].Name} = {settingSection.StrSetting}");
        foreach (var item in settingSection.SuctomSettingList)
        {
          var subSetting = item as CustomSectionElement;
          if (subSetting != null)
            Console.WriteLine($"{subSetting.GetType().GetProperties()[0].Name} = {subSetting.SubSetting} {subSetting.GetType().GetProperties()[1].Name} = {subSetting.SubSettingValue}");
        }
      }

      Console.ReadKey();

      // Задание 5.
      Console.WriteLine("Задание 5");
      assemblyPath = Path.GetFullPath(@".\TestAssembly_1.dll");
      AssemblyTools.ShowAllReadWriteProperties(assemblyPath, className);
      Console.ReadKey();
    }
  }
}
