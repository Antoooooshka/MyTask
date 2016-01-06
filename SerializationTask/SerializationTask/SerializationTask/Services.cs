using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace SerializationTask
{
    class Services
    {

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        XmlSerializer xs = new XmlSerializer(typeof(Employee));

        public void XmlSerializerMethod(Employee emp, string xmlFileName)
        {
            using (Stream s = File.OpenWrite(xmlFileName))
            {
                xs.Serialize(s, emp);
            }
            Console.WriteLine("Объект сериализован");
        }

        public Employee XmlDeSerializerMethod(string xmlFilename)
        {
            Employee emp = null;

            if (File.Exists(xmlFilename))
            {
                using (Stream s = File.OpenRead(xmlFilename))
                {
                    emp = (Employee)xs.Deserialize(s);
                }
            }
            return emp;
        }

        public void BinnarySerializermethod(Employee employee, string fileName)
        {

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, employee);
            }
            Console.WriteLine("Объект сериализован");
        }

        public Employee BinnaryDeSerializerMethod(string fileName)
        {
            Employee emp;
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                emp = (Employee)binaryFormatter.Deserialize(fs);
            }
            return emp;
        }

    }
}
