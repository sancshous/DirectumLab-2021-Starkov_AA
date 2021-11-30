using NUnit.Framework;
using System.IO;
using System.Windows.Forms;
using Task_7;

namespace Task7_12Tests
{
  [TestFixture]
  public class Task7UnitTests
  {
    [Test]
    public void LoadGZippedTextTest()
    {
      var expectedRichTextBox = new RichTextBox();
      var testPath = Path.GetFullPath(@".\Task7_12Tests\q2.rtf");
      using (var streamReader = new StreamReader(testPath, System.Text.Encoding.Default))
      {
        expectedRichTextBox.Rtf = streamReader.ReadToEnd();
      }

      var richTextBox = new RichTextBox();
      var path = Path.GetFullPath(@".\Task7_12Tests\q2.rtf.gz");
      RtfLoader.LoadGZippedText(path, richTextBox);

      Assert.AreEqual(expectedRichTextBox.ToString(), richTextBox.ToString());
    }
  }
}
