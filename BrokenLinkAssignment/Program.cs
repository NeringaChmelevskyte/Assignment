using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenLinkAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Congratulations, you need to implement our empty datastructure but not change the contracts and you cannot use already existing LinkedList class in .NET
            // make sure all tests are green (do not edit tests)
            // find and fix any bugs you encounter
            // create a list here 
            // add 100 random members to it
            // print all 100 members to console

            var list = new SpecialLinkedList<int>();
            Random rnd = new Random();
            for(int i = 0; i < 100; i++)
            {
                list.Add(rnd.Next());
            }
            Console.WriteLine(list.ToString());
            
          
        }
    }
}
