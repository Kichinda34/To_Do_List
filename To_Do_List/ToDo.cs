using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    internal class ToDo
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public Person Owner { get; set; }

        public DateTime Created { get; set; }

        public DateTime DueDate { get; set; }

        public bool Status { get; set; } 

        public ToDo ToDo()
        {

        }

        public string ToFile ()
        {

        }

        public bool SetStatus()
        {

        }

        public Person Person()
        {

        }

        public override string ToString()
        {
            
        }
    }
}
