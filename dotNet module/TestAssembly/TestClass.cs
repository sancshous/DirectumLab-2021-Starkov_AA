using System;

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
      this.Age = 42;
      this.FirstName = "Ivan";
      this.LastName = "Ivanov";
    }
  }
}
