using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }

        public Person(string name, string id, string email)
        {
            Name = name;
            ID = id;
            Email = email;
        }

        public abstract void Introduce();
    }
}
