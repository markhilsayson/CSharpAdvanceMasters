﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    public class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Cat(string name,int age)
        {
            Name = name;
            Age = age;
        }

        public void Talk()
        {
            Console.WriteLine("Meow! Meow!");
        }

        public void Jump()
        {
            Console.WriteLine("The Cat is jumping!");
        }
        public void Walk()
        {
            Console.WriteLine("The Cat is walking!");
        }
    }
}
