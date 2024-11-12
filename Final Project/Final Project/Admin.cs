using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Project
{
    public class Admin : Person
    {
        public string Role { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();

        public Admin(string name, string id, string email, string role)
            : base(name, id, email)
        {
            Role = role;
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hello, I am {Name}, an admin with the role of {Role}.");
        }
    }
}
