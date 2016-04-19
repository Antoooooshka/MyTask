namespace marmeladka.core.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
