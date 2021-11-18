using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
  /// <summary>
  /// When you implement IEnumerable(T), you must also implement IEnumerator(T),
  /// which will walk through the contents of the file one line at a time.
  /// Implementing IEnumerator(T) requires that you implement IEnumerator and IDisposable.
  /// </summary>
  public class StreamReaderEnumerator : IEnumerator<string>
  {
    private StreamReader reader;
    private string current;
    private bool disposedValue = false;

    /// <summary>
    /// Конструктор StreamReaderEnumerator.
    /// </summary>
    /// <param name="filePath">Путь файла.</param>
    public StreamReaderEnumerator(string filePath)
    {
      this.reader = new StreamReader(filePath);
    }

    /// <summary>
    /// Implement the IEnumerator(T).Current publicly, but implement
    /// IEnumerator.Current, which is also required, privately.
    /// </summary>
    public string Current
    {
      get
      {
        if (this.reader == null || this.current == null)
        {
          throw new InvalidOperationException();
        }

        return this.current;
      }
    }

    private object Current1
    {
      get { return this.Current; }
    }

    object IEnumerator.Current
    {
      get { return this.Current1; }
    }


    /// <summary>
    /// Implement MoveNext and Reset, which are required by IEnumerator.
    /// </summary>
    /// <returns>Возвращает true, если после строки можно считать еще строку.</returns>
    public bool MoveNext()
    {
      this.current = this.reader.ReadLine();
      if (this.current == null)
        return false;
      return true;
    }

    public void Reset()
    {
      this.reader.DiscardBufferedData();
      this.reader.BaseStream.Seek(0, SeekOrigin.Begin);
      this.current = null;
    }

    /// <summary> 
    /// Implement IDisposable, which is also implemented by IEnumerator(T).
    /// </summary>
    public void Dispose()
    {
      this.Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposedValue)
      {
        if (disposing)
        {
          // Dispose of managed resources.
        }
        this.current = null;
        if (this.reader != null)
        {
          this.reader.Close();
          this.reader.Dispose();
        }
      }

      this.disposedValue = true;
    }

    ~StreamReaderEnumerator()
    {
      this.Dispose(disposing: false);
    }
  }
}