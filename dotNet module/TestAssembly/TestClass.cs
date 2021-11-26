using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
    public class TestClass
    {
    public int age;
    public string firstName;
    public string lastName;

    [property: Obsolete("use newer properties")]
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public TestClass()
    {
      this.Age = 18;
      this.FirstName = "Pasha";
      this.LastName = "Petrov";
    }
  }
}
