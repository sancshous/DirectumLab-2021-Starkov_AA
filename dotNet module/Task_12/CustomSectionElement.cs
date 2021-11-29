using System.Configuration;

namespace Task_12
{
  public class CustomSectionElement : ConfigurationElement
  {
    [ConfigurationProperty("SubSetting", IsKey = true, IsRequired = true)]
    public string SubSetting => (string)this["SubSetting"];

    [ConfigurationProperty("SubSettingValue", IsKey = true, IsRequired = true)]
    public string SubSettingValue => (string)this["SubSettingValue"];
  }
}
