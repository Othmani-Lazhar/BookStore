namespace BookStore.Core.Configuration
{
    using System.Xml.Serialization;

    [XmlRoot]
    public class ApplicationSetting
    {
        public ApplicationSetting()
        {
            
        }
        [XmlElement]
        public string HostAddres { get; set; }

        [XmlElement]
        public string LoginPagePath { get; set; }

        [XmlElement]
        public string PictureUploadFolder { get; set; }
    }
}
