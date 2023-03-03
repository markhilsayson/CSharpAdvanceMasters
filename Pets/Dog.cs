using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    public class Dog
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Talk()
        {
            Console.WriteLine("Woof! Woof!");
        }

        public void Walk()
        {
            Console.WriteLine("Dog is walking!");
        }

        public void Jump()
        {
            Console.WriteLine("Dog is Jumping!");
        }
    }
}
