using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LocalizedApp
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    static App()
    {
      System.Threading.Thread.CurrentThread.CurrentUICulture =
        new System.Globalization.CultureInfo("ru");
    }

  }
}
