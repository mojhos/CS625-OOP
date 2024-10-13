using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackLibrary
{
	public class Person
	{
		#region Properties
		
		public String? Name { get; set; }
		public DateTimeOffset Born { get; set; }
		public List<Person> Children = new();
		
		//Allow multiple spouses to be stored for a person
		public List<Person> Spouses = new();

		//A readonly field to show is a person is married to anyone
		public bool Married => Spouses.Count > 0;

		//public bool Married()
		//{
		//	return Spouses.Count > 0; // same as above
		//}

		#endregion

		#region Methods

		public void WriteToConsole()
		{
			Console.WriteLine($"{Name} was born on a {Born:dddd}");
		}

		public void WriteChildrenToConsole()
		{
			string term = Children.Count == 1 ? "child" : "children";
			Console.WriteLine($"{Name} has {Children.Count} {term}.");
		}

		//static method to marry two people
		public static void Marry(Person p1, Person p2)
		{
			ArgumentNullException.ThrowIfNull(p1);
			ArgumentNullException.ThrowIfNull(p2);

			if (p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1))
			{
				throw new ArgumentException(string.Format("{0} is already married to {1}.", arg0:p1.Name, arg1: p2.Name));
			}

			p1.Spouses.Add(p2);
			p2.Spouses.Add(p1);
		}

		public void Marry(Person partner)
		{
			Marry(this, partner); //this; --> current person
		}

		public void OutputSpouses()
		{
			if(Married)
			{
				string term = Spouses.Count == 1 ? "person" : "people";
				Console.WriteLine($"{Name} is married to {Spouses.Count} {term}:");

				foreach (var spouse in Spouses)
				{
					Console.WriteLine($"{spouse.Name}");
				}
			}
			else
			{
				Console.WriteLine($"{Name} is single.");
			}
		}

		//procreate
		public static Person Procreate(Person p1, Person p2)
		{
			ArgumentNullException.ThrowIfNull(p1);
			ArgumentNullException.ThrowIfNull(p2);
			if (!p1.Spouses.Contains(p2) && p2.Spouses.Contains(p1))
			{
				throw new ArgumentException(string.Format("{0} must be married to {1} to procreate with them.",
					arg0: p1.Name, arg1: p2.Name));
			}

			Person baby = new()
			{
				Name = $"Baby of {p1.Name} and {p2.Name}",
				Born = DateTimeOffset.Now
			};

			p1.Children.Add(baby);
			p2.Children.Add(baby);

			return baby;
		}

		//instance method for procreate
		public Person ProcreateWith(Person partner)
		{
			return Procreate(this, partner);
		}

        
        #endregion

        #region Operators

        //Define the + operator to marry
        public static bool operator +(Person a, Person b)
		{
			Marry(a, b);

			return a.Married && b.Married;
		}

		//define the * operator to procreate (multiply)
		public static Person operator *(Person a, Person b)
		{
			//return a ref to the baby that results from 'multiplying'
			return Procreate(a, b);
		}

        #endregion



        //#############################################ADDED CODE##############################################
        //###########################################FOR ASSIGNMENT##############################################
        //ASSIGNMENT
        //1. implement methods that will check if a married couple has kids, and if not let them adopt kids
        //2. Also implement isStepChild method / property, that will check if a baby is a stepchild 
        //3. Implement the parents method to show parents of a baby.
        //Show code output
        #region Added_Properties

        // Method to check if a married couple has kids
        public static bool HasChildren(Person p1)
        {
            return p1.Children.Count > 0;
        }

        public DateTimeOffset AdoptDate { get; set; }

		public bool IsAdopted { get; set; }

        // Property to check if a child is a stepchild
        public bool IsStepChild(Person child)
        {
            return (child.IsAdopted);
        }

        #endregion

        #region Added_Methods
        
		// Method to allow a married couple to adopt a child
        public static Person AdoptChild(string childName, Person p1, Person p2)
        {
            if ( !(p1.Spouses.Contains(p2) && p2.Spouses.Contains(p1)) || HasChildren(p1) || HasChildren(p2))
            {
                throw new ArgumentException(string.Format("{0} and {1} cannot adopt a child if they already have biological children or are not married.", arg0: p1.Name, arg1: p2.Name));  
                
            }

            Person adoptedChild = new()
            {
                Name = childName,
                AdoptDate = DateTimeOffset.Now,
				IsAdopted = true
				
            };

            p1.Children.Add(adoptedChild);
			p2.Children.Add(adoptedChild);

			return adoptedChild;

        }



        // Method to get parents of a child
        public List<Person> GetParents(Person child)
        {
            List<Person> parents = new();
			parents.Add(this);

            foreach (var spouse in Spouses)
            {
                if (spouse.Children.Contains(child))
                {
                    parents.Add(spouse);
                }
            }

            return parents;
        }

        #endregion

    }
}

