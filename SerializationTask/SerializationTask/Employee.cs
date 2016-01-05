using System;

namespace SerializationTask
{
    [Serializable]
    public class Employee
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
    }
}
