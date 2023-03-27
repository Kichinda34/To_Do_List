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

        public Person Person()
        {
            return new Person();
        }

        public Person SetName()
        {

        }

        public override string ToString()
        {
            
        }
    }
}
