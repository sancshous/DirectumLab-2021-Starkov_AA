﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7
{
  /// <summary>
  /// Класс формы.
  /// </summary>
  public partial class Form1 : Form
  {
    /// <summary>
    /// Создает обьект типа RichTextBox.
    /// </summary>
    /// <returns>Возвращает обьект типа RichTextBox.</returns>
    public RichTextBox CreateRichTextBox()
    {
      var richTextBox1 = new RichTextBox();
      richTextBox1.Dock = DockStyle.Fill;
      this.Controls.Add(richTextBox1);
      return richTextBox1;
    }

    /// <summary>
    /// Загружает данные из текстового файла, сжатого по методу GZIP, в RichTextBox.
    /// </summary>
    /// <param name="filename">Текстовый файл, сжатый по методу GZIP.</param>
    /// <param name="textBox">Обьект типа RichTextBox.</param>
    public void LoadGZippedText(string filename, RichTextBox textBox)
    {
      using (var sourceStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)) 
      using (var uncompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true))
      using (var textReader = new StreamReader(uncompressedStream, true))
        textBox.Rtf = textReader.ReadToEnd();
    }

    /// <summary>
    /// Конструктор формы.
    /// </summary>
    public Form1()
    {
      this.InitializeComponent();
      this.LoadGZippedText("q2.rtf.gz", this.CreateRichTextBox());
    }
  }
}