using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    public class Bird
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Bird(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Talk() { 
            Console.WriteLine("Tweet Tweet!");
        }

        public void Walk() {
            Console.WriteLine("Bird is walking!");
        }

        public void Jump() {
            Console.WriteLine("Bird is Jumping!");
        }

        public void Fly() {
            Console.WriteLine("Bird is Flying!");
        }
    }
}
