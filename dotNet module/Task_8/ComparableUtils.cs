using System;
using System.Collections.Generic;
using System.Text;

namespace Task_8
{
  /// <summary>
  /// Generic класс для IComparable значений.
  /// </summary>
  /// <typeparam name="T">Generic тип.</typeparam>
  public class ComparableUtils<T> where T : IComparable
  {
    /// <summary>
    /// Нахождение максимального значения из 3 элементов любого, но одного типа.
    /// </summary>
    /// <param name="value1">Значение 1.</param>
    /// <param name="value2">Значение 2.</param>
    /// <param name="value3">Значение 3.</param>
    /// <returns>Возвращает максимум из 3.</returns>
    public static T MaxValue(T value1, T value2, T value3)
    {
      if (value1.CompareTo(value2) > 0)
        return value1.CompareTo(value3) > 0 ? value1 : value3;
      else
        return value2.CompareTo(value3) > 0 ? value2 : value3;
    }
  }
}
