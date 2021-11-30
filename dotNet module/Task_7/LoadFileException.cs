using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
  /// <summary>
  /// Класс собственных исключений.
  /// </summary>
  public class LoadFileException : Exception
  {
    public LoadFileException(string message) : base(message)
    {
    }
  }
}
