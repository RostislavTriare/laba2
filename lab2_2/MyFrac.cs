using System;
namespace Laba2_2
{
    class MyFrac
    {

        public int nom=0, denom=0;

        
        public MyFrac(int nom, int denom)
        {

            this.nom = Math.Abs(nom);
            this.denom = Math.Abs(denom);
            
        }
        public String Cheloe()
        {
            int k = 0;
            int nom1 = nom;
            int denom1 = denom;
            while ((nom1/denom1)>=1)
            {
                nom1 = nom1 - denom1;
                k++;
            }
            

            return $"Ціла части = {k}";
        }
        public double MyDrob()
        {
            
            double dill = (double)nom/ denom;
     
            return dill;
        }

        public double Sum()
        {
            int nom1 = nom;
            int denom1 = denom;

            int nom2 = 20;
            int denom2 = 17;
            if (nom2 <=0){
            nom2 = nom2 * -1
            }
            if (denom2 <=0){
            denom2 = denom2 * -1
            }
            double rez = (double)(nom1 * denom2 + nom2*denom1)/(denom1*denom2);
            return rez;
           
        }

        public double Minum()
        {
            int nom1 = nom;
            int denom1 = denom;

            int nom2 = 20;
            int denom2 = 17;
if (nom2 <=0){
            nom2 = nom2 * -1
            }
            if (denom2 <=0){
            denom2 = denom2 * -1
            }
            double rez= (double)(nom1 * denom2 - nom2 * denom1) / (denom1 * denom2);
            return rez;

        }

        public double Mnog()
        {
            int nom1 = nom;
            int denom1 = denom;

            int nom2 = 20;
            int denom2 = 17;
if (nom2 <=0){
            nom2 = nom2 * -1
            }
            if (denom2 <=0){
            denom2 = denom2 * -1
            }
            double rez = (double)(nom1 *  nom2 ) / (denom1 * denom2);
            return rez;

        }
        public double Devide()
        {
            int nom1 = nom;
            int denom1 = denom;
if (nom2 <=0){
            nom2 = nom2 * -1
            }
            if (denom2 <=0){
            denom2 = denom2 * -1
            }
            int nom2 = 20;
            int denom2 = 17;

            double rez = (double)(nom1 * denom2) / (denom1 * nom2);
            return rez;

        }
        public int GetRGR113LeftSum()
        {
            
            double rez = 0.00;
            
            int i = 0;
            while (i <= 9){ rez +=(1.00 / (2.00 * i + 1.00)); i++;  }
            
            return (int)rez;

        }
        public double GetRGR115LeftSum()
        {

            double rez = 1.00;

            int i = 0;
            while (i <= 9) { rez *= (1.00 / (2.00 * i + 1.00)); i++; }

            return rez;

        }
        public int normal()
        {
            int x, y, NOD;
            x = nom;
            y = denom;
            while (Math.Abs(x) != Math.Abs(y))
            {
                if (x > y)
                    x = x - y;
                else y = y - x;
            }
            NOD = x;
            return x;
        }
        
        
        public override String ToString()
        {
            String num;
            int a = nom, b = denom;
            int dil = normal();
            denom = denom / dil;
            nom = nom / dil;
            if (dil == 1)
            {
                num = ("0");
            }
            else
            {
                num = ($"Первинний = {a}/{b} Результат = {nom}/{denom}");
            }
            return num;
        }
        

    }
}
