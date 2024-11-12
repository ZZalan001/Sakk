using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] tabla1 = new string[8, 8];
            for (int i = 0; i < tabla1.GetLength(0); i++)
            {
                for (global::System.Int32 j = 0; j < tabla1.GetLength(1); j++)
                {
                    tabla1[i, j] = "0";
                }
                
            }
            Allas aktualisAllas = new Allas(0, "Kiss Elemér", "Füty Imre", tabla1, true);
            Console.WriteLine(aktualisAllas);



            Console.ReadLine();
        }
    }
}
