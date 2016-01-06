using System;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;


namespace SerializationTask
{
    [Serializable]
    public class Organization : IXmlSerializable
    {
        public string OrganizationName { get; set; }

        public string Adress { get; set; }
          


        public Organization() { }

        public Organization(string organizationName, string adress)
        {
            OrganizationName = organizationName;
            Adress = adress;
        }


        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement();
            PropertyInfo[] prop = this.GetType().GetProperties();

            for (int i = 0; i < prop.Length; i++)
            {
                string val = reader.ReadElementContentAsString(prop[i].Name, "");
                prop[i].SetValue(this, val);
            }

            reader.ReadEndElement();

        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Organization");
            writer.WriteElementString("OrganizationName",OrganizationName);
            writer.WriteElementString("Adress", Adress);
            writer.WriteEndElement();
        }
    }
}
