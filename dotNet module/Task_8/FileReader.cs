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
    /// Конструктор StreamReaderEnumerable
    /// </summary>
    /// <param name="filePath">Путь файла.</param>
    public FileReader(string filePath)
    {
      this.filePath = filePath;
    }

    /// <summary>
    /// Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
    /// </summary>
    /// <returns>Возвращает new StreamReaderEnumerator.</returns>
    public IEnumerator<string> GetEnumerator()
    {
      return new FileReaderEnumerator(this.filePath);
    }

    /// <summary>
    /// Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    /// </summary>
    /// <returns>Возвращает new StreamReaderEnumerator.</returns>
    private IEnumerator GetEnumerator1()
    {
      return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator1();
    }
  }
}
