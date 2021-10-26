using System;

namespace Laba2_2
{



    class MainClass
    {
        public static void Main(string[] args)
        {
            MyFrac my= new MyFrac(28,27);
            Console.WriteLine(my.nom);
            Console.WriteLine(my.denom);
            Console.WriteLine(my.Cheloe());
            Console.WriteLine(my.MyDrob());
            Console.WriteLine(my.Sum());
            Console.WriteLine(my.Minum());
            Console.WriteLine(my.Mnog());
            Console.WriteLine(my.Devide());
            Console.WriteLine(my.GetRGR113LeftSum());
            Console.WriteLine(my.GetRGR115LeftSum());
            Console.WriteLine(my.ToString());
           

        }
    }
}
