using System;

namespace SerializationTask
{
    class Program
    {
        static void Main()
        {
            Organization artezio = new Organization("Artezio","cool adress");
            Employee emp = new Employee(24, "Anton", "Male", artezio);
            Services serv = new Services("Employee.xml");

            Employee emp2;

            serv.BinnarySerializermethod(emp);

            emp2 = serv.BinnaryDeSerializerMethod();

            Console.WriteLine(emp2.Name);
            Console.WriteLine(emp2.Organization.OrganizationName);
            Console.ReadLine();



        }

       

       
    }
}
