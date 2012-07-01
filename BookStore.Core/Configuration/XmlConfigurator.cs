namespace BookStore.Core.Configuration
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlConfigurator
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\ApplicationSetting.xml";

        public static ApplicationSetting GetSetting()
        {
            XmlSerializer serilaizer = new XmlSerializer(typeof(ApplicationSetting));

            using (var filestream = File.OpenRead(path))
            {
                return serilaizer.Deserialize(filestream) as ApplicationSetting;
            }
        }

        public static void SetSetting(ApplicationSetting setting)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSetting));

            using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                serializer.Serialize(filestream, setting);
            }
        }
    }
}
