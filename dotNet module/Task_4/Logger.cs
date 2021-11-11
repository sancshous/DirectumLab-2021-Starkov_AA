﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_4
{
  /// <summary>
  /// Логгер - класс для ведения логов.
  /// </summary>
  public class Logger : IDisposable
  {
    /// <summary>
    /// Файллогов.
    /// </summary>
    private FileStream logFile;

    /// <summary>
    /// Писательвлог.
    /// </summary>
    private StreamWriter logWriter;

    /// <summary>
    /// Создатьобъект.
    /// </summary>
    /// <param name="fileName">Имя файла логов.</param>
    public Logger(string fileName)
    {
      this.logFile = new FileStream(fileName, FileMode.Append);
      this.logWriter = new StreamWriter(this.logFile);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
      this.logWriter.Dispose();
      this.logFile.Dispose();
    }

    /// <summary>
    /// Записать строку в файл.
    /// </summary>
    /// <param name="data">Записываемая строка в файл.</param>
    public void WriteString(string data)
    {
      this.logWriter.WriteLine(data);
    }
  }
}
