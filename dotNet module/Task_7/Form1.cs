using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      this.InitializeComponent();
      var textbox = RtfLoader.CreateRichTextBox();
      this.Controls.Add(textbox);
      RtfLoader.LoadGZippedText("q2.rtf.gz", textbox);
    }
  }
}
