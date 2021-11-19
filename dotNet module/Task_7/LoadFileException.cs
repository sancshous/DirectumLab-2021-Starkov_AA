using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Task_7
{
  /// <summary>
  /// Класс собственных исключений.
  /// </summary>
  public class LoadFileException : Exception
  {
    public LoadFileException(string message) : base(message)
    {
      MessageBox.Show(message);
    }
  }
}
