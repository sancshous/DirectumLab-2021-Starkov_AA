using System.Drawing;
using System.Windows.Forms;

namespace Task_7
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
    /// <param name="edit">Обьект типа RichTextBox.</param>
    public void LoadGZippedText(string filename, RichTextBox edit)
    {
      using (var sourceStream = new System.IO.FileStream(filename,
              System.IO.FileMode.Open, System.IO.FileAccess.Read,
              System.IO.FileShare.Read))
      using (var uncompressedStream = new System.IO.Compression.GZipStream(
              sourceStream, System.IO.Compression.CompressionMode.Decompress, true))
      using (var textReader = new System.IO.StreamReader(uncompressedStream, true))
        edit.Rtf = textReader.ReadToEnd();
    }

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Text = "Form1";
    }

    #endregion
  }
}

