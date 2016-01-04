using System;
using System.Xml.Serialization;

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
            reader.MoveToContent();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
