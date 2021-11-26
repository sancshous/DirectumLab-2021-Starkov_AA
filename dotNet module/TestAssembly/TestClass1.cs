using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
  public class TestClass1
  {
    public bool isTropic;
    public string language;
    public string country;

    public bool IsTropic { get; set; }
    public string Language { get; set; }
    public string Country { get; set; }

    public TestClass1()
    {
      this.IsTropic = false;
      this.Language = "English";
      this.Country = "Germany";
    }
  }
}
