using NUnit.Framework;
using System.IO;
using System.Text;
using Task_12;
using TestAssembly;

namespace Task12UnitTests
{
  [TestFixture]
  public class Task12UnitTests
  {
    [Test]
    public void ShowAllReadWritePropertiesTest()
    {
      var testObject = new TestClass();
      var expected = new StringBuilder();

      expected.AppendLine("System.Int32 Age 18");
      expected.AppendLine("System.String FirstName Pasha");
      expected.AppendLine("System.String LastName Petrov");

      var propertiesInfo = AssemblyTools.ShowAllReadWriteProperties(testObject);

      Assert.AreEqual(expected.ToString(), propertiesInfo);
    }

    [Test]
    public void ShowNewestPropertiesTest()
    {
      var expected = new StringBuilder();
      expected.AppendLine("System.String FirstName Pasha");
      expected.AppendLine("System.String LastName Petrov");

      var path = Path.GetFullPath(@".\Task7_12Tests\TestAssembly.dll");
      var propertiesInfo = AssemblyTools.ShowNewestProperties(path, "TestAssembly.TestClass");

      Assert.AreEqual(expected.ToString(), propertiesInfo);
    }
  }
}
