using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
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

        public Employee()
        {
            Organization = new Organization();
        }

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
            PropertyInfo[] prop = this.GetType().GetProperties();

            reader.MoveToContent();
            reader.ReadStartElement();

            for (int i = 0; i < prop.Length; i++)
            {
                if (prop[i].PropertyType == typeof(string))
                {
                    string temp = reader.ReadElementContentAsString(prop[i].Name, "");
                    prop[i].SetValue(this, temp);
                }
                else if (prop[i].PropertyType == typeof(Organization))
                {
                    Organization.ReadXml(reader);
                }
                else if (prop[i].PropertyType == typeof(int))
                {
                    int temp = reader.ReadElementContentAsInt(prop[i].Name, "");
                    prop[i].SetValue(this, temp);
                }
            }

        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("Age",Age.ToString());
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Gender", Gender);
            Organization.WriteXml(writer);
        }

    }
}
