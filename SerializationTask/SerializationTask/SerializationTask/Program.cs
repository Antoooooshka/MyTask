using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace SerializationTask
{
    class Program
    {
        static void Main()
        {
            Organization artezio = new Organization("Artezioooo","cool adress");
            Employee emp = new Employee(24, "Antonnnn", "Male", artezio);
            Services serv = new Services();

            Employee emp2 = new Employee();

            serv.XmlSerializerMethod(emp,"file.xml");
            emp2 = serv.XmlDeSerializerMethod("file.xml");

            Console.WriteLine("Age {0}, Name {1}, OrganizationName {2}", emp2.Age, emp2.Name, emp2.Organization.OrganizationName);
            
            Console.ReadLine();

        }




    }
}
