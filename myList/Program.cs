using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidirectionalList;

namespace myList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedLis a = new LinkedLis();
            a.AddLast(1);
            a.AddLast(3);
            a.AddLast(7);
            a.AddLast(9);
            a.AddLast(10);

            a = LinkedLis.RemoveByCodition(a, i => (i > 3));

            foreach (int i in a)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine(); //Pause
            Console.ReadLine(); //Pause
        }
    }
}
