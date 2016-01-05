using System;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;

namespace SerializationTask
{
    [Serializable]
    public class Employee : IXmlSerializable
    {
        
        public int Age { get; set; }
        
        public string Name { get; set; }
        
        public string Gender { get; set; }
        
        public Organization Organization { get; set; }

        public Employee() { }

        public Employee(int age, string name, string gender, Organization organiz)
        {
            Age = age;
            Name = name;
            Gender = gender;
            Organization = organiz;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            Organization = new Organization();
            Type t = Organization.GetType();
            MethodInfo mi = t.GetMethod("ReadXml");
            if (reader.MoveToContent() == XmlNodeType.Element)
            {
                reader.ReadStartElement();
                Age = Convert.ToInt32(reader.ReadElementContentAsString("Age",""));
                Name = reader.ReadElementContentAsString("Name","");
                Gender = reader.ReadElementContentAsString("Gender", "");
                Organization.ReadXml(reader);
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("Age", Age.ToString());
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Gender", Gender);
            Organization.WriteXml(writer);
        }
    }
}
