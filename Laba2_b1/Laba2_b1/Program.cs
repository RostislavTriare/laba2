using System;

namespace Laba2_b1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
           

            Console.WriteLine("Конструктор двовимірного масиву типу double[,]");
            double[,] mtrx_1 = { { 10, 2, 33 }, { 14, 65, 60 }, { 27, 38, 1 } };
            MyMatrix myMatrix_1 = new MyMatrix(mtrx_1);
            Console.WriteLine(myMatrix_1);

            Console.WriteLine("Конструктор копіювання");
            MyMatrix myMatrix_2 = new MyMatrix(myMatrix_1);
            Console.WriteLine(myMatrix_2.JavaToString());

            Console.WriteLine("Конструктор з \"зубчатого\" масиву");
            double[][] mtrx_2 = new[]
            {
                new double[] { 5, 23, 23 },
                new double[] { 8, 54, 26 },
                new double[] { 1, 85, 91 },
                new double[] { 11, 21, 52 }
            };
            MyMatrix myMatrix_3 = new MyMatrix(mtrx_2);
            Console.WriteLine(myMatrix_3);

            Console.WriteLine("Конструктор з масиву рядків");
            string[] mtrx_3 = {
                "0,44 5,33 2,67",
                "3,28 0,54 9,99",
                "-0,8 1,05 -0,9",
                "992 171 -111",
                "121 406 780" };
            MyMatrix myMatrix_4 = new MyMatrix(mtrx_3);
            Console.WriteLine(myMatrix_4.JavaToString());

            Console.WriteLine("Конструктор з рядка");
            string vs = myMatrix_4.JavaToString();
            MyMatrix myMatrix_5 = new MyMatrix(vs);
            Console.WriteLine(myMatrix_5);

            Console.WriteLine("Транспонована матриця");
            myMatrix_5.TransponeMe();
            Console.WriteLine(myMatrix_5);

            Console.WriteLine("Додавання двох матриць");
            Console.WriteLine(myMatrix_4 + myMatrix_4);
            Console.WriteLine("Множення двох матриць");
            Console.WriteLine(myMatrix_1 * myMatrix_2);

            Console.ReadKey();
        }
    }
}
