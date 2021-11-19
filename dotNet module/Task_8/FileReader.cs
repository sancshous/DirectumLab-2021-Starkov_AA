using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_8
{
  /// <summary>
  /// A custom class that implements IEnumerable(T). When you implement IEnumerable(T),
  /// you must also implement IEnumerable and IEnumerator(T).
  /// </summary>
  public class FileReader : IEnumerable<string>
  {
    private readonly string filePath;

    /// <summary>
    /// Конструктор FileReaderEnumerator.
    /// </summary>
    /// <param name="filePath">Путь файла.</param>
    public FileReader(string filePath)
    {
      this.filePath = filePath;
    }

    /// <summary>
    /// Must implement GetEnumerator, which returns a new FileReaderEnumerator.
    /// </summary>
    /// <returns>Возвращает new FileReaderEnumerator.</returns>
    public IEnumerator<string> GetEnumerator()
    {
      return new FileReaderEnumerator(this.filePath);
    }

    /// <summary>
    /// Must also implement IEnumerable.GetEnumerator.
    /// </summary>
    /// <returns>Возвращает new FileReaderEnumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
