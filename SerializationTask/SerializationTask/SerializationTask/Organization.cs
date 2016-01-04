using System;

namespace SerializationTask
{
    [Serializable]
    public class Organization
    {
        public string OrganizationName { get; set; }

        public string Adress { get; set; }

        public Organization() { }

        public Organization(string organizationName, string adress)
        {
            OrganizationName = organizationName;
            Adress = adress;
        }

    }
}
