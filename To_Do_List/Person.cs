using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    internal class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Person (string name)
        {
            Id = this.Id; 
            Name = name;
        }

        public Person ()
        {
            Id = Guid.NewGuid ();
        }

        public Person SetName(string name)
        {
            this.Name = name;
            return this;
        }
    }
}
