using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    public class Fish
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Talk()
        {
            Console.WriteLine("Gulf! Gulf!");
        }

        public void Jump()
        {
            Console.WriteLine("The Fish is jumping!");
        }
        public void Swim()
        {
            Console.WriteLine("The Fish is swimming!");
        }
    }
}
