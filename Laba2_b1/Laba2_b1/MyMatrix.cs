using System;

namespace Laba2_b1
{
    public class MyMatrix
    {
        private double[,] mtrx_;

        public int Height                             //Властивості
        { get { return mtrx_.GetLength(0); } }
        
        public int getHeight()
        { return mtrx_.GetLength(0); }
        
        public int Width
        { get { return mtrx_.GetLength(1); } }
        
        public int getWidth()
        { return mtrx_.GetLength(1); }

        public double this[int i, int j]   // Індексатор
        {
            get { return mtrx_[i, j]; }
            set { mtrx_[i, j] = value; }
        }

        public double GetJava(int i, int j)    //Геттер по джавистски
        { return mtrx_[i, j]; }

        public void SetJava(int i, int j, double value)      //Сеттер по джавистски
        { mtrx_[i, j] = value; }

        public MyMatrix(MyMatrix other)                                         //копіюючий з іншого примірника цього самого класу MyMatrix;
        { this.mtrx_ = other.mtrx_; }

        public MyMatrix(double[,] other)                                        //з двовимірного масиву типу double[,];
        { this.mtrx_ = other; }

        public MyMatrix(double[][] other)                                       //з «зубчастого» масиву double-ів, якщо він фактично прямокутний;
        {
            bool check = true;
            for (int i = 1; i < other.Length; i++)                              //перевірка "зубчатого" масиву на фактичну прямокутність;
                if (other[i].Length != other[0].Length)
                    check = false;
            if (check)
            {
                double[,] matrix = new double[other.Length, other[0].Length];
                for (int i = 0; i < other.Length; i++)
                    for (int j = 0; j < other[0].Length; j++)
                        matrix[i, j] = other[i][j];
                this.mtrx_ = matrix;
            }
            else
                throw new Exception("Матриця має бути прямокутна");
        }

        public MyMatrix(string[] other)            // Парсер стринг в дабл
        {            
            string[][] matrix = new string[other.Length][];
            for (int i = 0; i < other.Length; i++)
                matrix[i] = other[i].Split();            
            if (SquarenessChecking(matrix))            
                this.mtrx_ = ResultArray(matrix);
            else
                throw new Exception("Матриця має бути прямокутна");
        }

        public MyMatrix(string other)
        {
            string[] mtrx_strings = other.Split('\n');    //Парсер із одной строчки
            if (mtrx_strings[mtrx_strings.Length - 1] == "")
                Array.Resize(ref mtrx_strings, mtrx_strings.Length - 1);
            string[][] matrix = new string[mtrx_strings.Length][];
            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = mtrx_strings[i].Split('\t', ' ');
            if (SquarenessChecking(matrix))
                this.mtrx_ = ResultArray(matrix);
            else
                throw new Exception("Матриця має бути прямокутна");
        }

        override public String ToString()  // Стринг вивод
        {
            String result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (j != Width - 1)
                        result += this[i, j] + "\t";
                    else
                        result += this[i, j];
                }
                result += "\n";
            }
            return result;
        }

        public String JavaToString() //Вивод взятий з Геттера
        {
            String result = "";
            for (int i = 0; i < getHeight(); i++)
            {
                for (int j = 0; j < getWidth(); j++)
                {
                    if (j != getWidth() - 1)
                        result += GetJava(i, j) + "\t";
                    else
                        result += GetJava(i, j);
                }
                result += "\n";
            }
            return result;
        }

        private bool SquarenessChecking(string[][] matrix)                      //перевірка рядкового "зубчатого" масиву на фактичну прямокутність;
        {
            bool check = true;
            for (int i = 1; i < matrix.Length; i++)                
                if (matrix[i].Length != matrix[0].Length)
                    check = false;
            return check;
        }

        private double[,] ResultArray(string[][] matrix)                        //формування готової матриці
        {
            double[,] res = new double[matrix.Length, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[0].Length; j++)
                    res[i, j] = double.Parse(matrix[i][j]);
            return res;
        }

        public static MyMatrix operator +(MyMatrix a, MyMatrix b) //Перегрузка оператора додовання для матриці
        {
            MyMatrix res = new MyMatrix("1\n1");
            if (a.Height == b.Height && a.Width == b.Width)
            {
                double[,] c = new double[a.Height, b.Width];
                for (int i = 0; i < a.getHeight(); i++)
                    for (int j = 0; j < b.Width; j++)
                        c[i, j] = a.GetJava(i, j) + b.GetJava(i, j);
                res = new MyMatrix(c);
            }
            else            
                throw new Exception("Матриці мають бути однакового розміру");           
            return res;
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b) //Перегрузка оператора множення для матриці
        {
            MyMatrix res = new MyMatrix("1\n1");
            if (a.Height == b.Width)
            {
                double[,] c = new double[b.Width, a.Height];
                for (int i = 0; i < a.getWidth(); i++)
                    for (int j = 0; j < b.Height; j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < a.getHeight(); k++)
                            c[i, j] += a.GetJava(i, k) * b.GetJava(k, j);
                    }
                res = new MyMatrix(c);
            }
            else
                throw new Exception("Кількість стовпців першої матриці не рівно кількості рядків другої матриці.");
            return res;
        }

        private double[,] GetTransponedArray() //Метод для транспонування масиву
        {
            double[,] result = new double[Width, Height];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    result[j, i] = this[i, j];                           
            return result;
        }

        private MyMatrix GetTransponedCopy() //Копіювання транспонованого масиву
        { return new MyMatrix(GetTransponedArray()); }

        public void TransponeMe()  
        { this.mtrx_ = GetTransponedCopy().mtrx_; }
    }
}
