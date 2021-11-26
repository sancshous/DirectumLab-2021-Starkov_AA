using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
      // Здесь TestClass1.Country=England(это более старая версия dll).
      // Но в итоге, что во 2 задании, что в 5, Country=Germany(то есть более новая версия dll)
      Console.WriteLine("Задание 2");
      var assemblyName = "TestAssembly.dll";
      var className = "TestAssembly.TestClass1";
      AssemblyTools.ShowValuesReadProperties(assemblyName, className);
      Console.ReadKey();

      // Задание 3.
      Console.WriteLine("Задание 3");
      className = "TestAssembly.TestClass";
      AssemblyTools.ShowNewestProperties(assemblyName, className);
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
      // Здесь должно быть TestClass1.Country=Germany
      Console.WriteLine("Задание 5");
      var assemblyName1 = @"C:\Users\shura\Documents\GitHub\DirectumLab-2021-Starkov_AA\dotNet module\Task_12\bin\Debug\TestAssembly_1.dll";
      var className1 = "TestAssembly.TestClass1";
      AssemblyTools.ShowValuesReadProperties(assemblyName1, className1);
      Console.ReadKey();
    }
  }
}
