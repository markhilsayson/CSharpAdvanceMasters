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

        public void Talk()
        {
            Console.WriteLine("Tweet! Tweet!");
        }

        public void Jump()
        {
            Console.WriteLine("The Bird is jumping!");
        }
        public void Walk()
        {
            Console.WriteLine("The Bird is walking!");
        }

        public void Fly()
        {
            Console.WriteLine("The Bird is flying!");
        }
    }
}
