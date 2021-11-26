using System.Configuration;

namespace Task_12
{
  public class CustomSectionElementCollection : ConfigurationElementCollection
  {
    protected override ConfigurationElement CreateNewElement()
    {
      return new CustomSectionElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((CustomSectionElement)(element)).SubSetting;
    }
  }
}
