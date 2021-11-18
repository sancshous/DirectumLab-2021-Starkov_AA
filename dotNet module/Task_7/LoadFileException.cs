using System;
using System.Collections.Generic;
using System.Text;

namespace Task_7
{
  /// <summary>
  /// Класс собственных исключений
  /// </summary>
  class LoadFileException : Exception
  {
    public LoadFileException(string message) : base(message)
    { 
    }
  }
}
