using System.Configuration;

namespace Task_12
{
  public class CustomSection : ConfigurationSection
  {
    [ConfigurationProperty("IntSetting")]
    public int IntSetting => (int)this["IntSetting"];

    [ConfigurationProperty("StrSetting")]
    public int StrSetting => (int)this["StrSetting"];

    [ConfigurationProperty("", IsDefaultCollection = true)]
    public CustomSectionElementCollection SuctomSettingList => (CustomSectionElementCollection)this[string.Empty];
  }
}
