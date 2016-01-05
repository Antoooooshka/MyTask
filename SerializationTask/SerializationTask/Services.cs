using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTask
{
    class Services 
    {
        public string XmlFileName { get; private set; }

        public Services(string xmlFileName)
        {
            XmlFileName = xmlFileName;
        }

        private BinaryFormatter binaryFormatter = new BinaryFormatter();

        private XmlSerializer xs = new XmlSerializer(typeof(Employee));

        public void XmlSerializerMethod(Employee emp)
        {         
            using (Stream s = File.OpenWrite(XmlFileName))
            {
                xs.Serialize(s, emp);
            }
            Console.WriteLine("Объект сериализован");
        }

        public Employee XmlDeSerializerMethod()
        {
            Employee emp = new Employee();
            
            if (File.Exists(XmlFileName))
            {
                using (Stream s = File.OpenRead(XmlFileName))
                {
                    emp = (Employee) xs.Deserialize(s);
                }
            }
            return emp;
        }

        public void BinnarySerializermethod(Employee employee)
        {
            
            using (FileStream fs = new FileStream("Employee.dat",FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, employee);
            }
            Console.WriteLine("Объъект сериализован");
        }

        public Employee BinnaryDeSerializerMethod()
        {
            Employee emp;
            using (FileStream fs = new FileStream("Employee.dat", FileMode.OpenOrCreate))
            {
                emp = (Employee) binaryFormatter.Deserialize(fs);
            }
            return emp;
        }

    }
}
