using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Console.WriteLine("Gulp! Gulp!");
        }

        [Obsolete("use new Method Walks",true)]
        public void Walk()
        {
            Console.WriteLine("Fish is Walking!");
        }


        public void Walks() {
            Console.WriteLine("Fish Can't walk");
        }

        public void Jump()
        {
            Console.WriteLine("Fish is Jumping!");
        }
    }
}
