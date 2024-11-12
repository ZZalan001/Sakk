using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk
{
    internal class Program
    {
        static List<Allas> allasok = new List<Allas>();
        static void Main(string[] args)
        {
            string[,] tabla1 = new string[8, 8];
            for (int i = 0; i < tabla1.GetLength(0); i++)
            {
                for (global::System.Int32 j = 0; j < tabla1.GetLength(1); j++)
                {
                    tabla1[i, j] = "  ";
                }
                
            }
            Allas aktualisAllas = new Allas(0, "Kiss Elemér", "Füty Imre", tabla1, true);
            allasok.Add(aktualisAllas);

            string[] bemenet = File.ReadAllLines("mentesek.txt");
            foreach (string sor in bemenet)
            {
                allasok.Add(new Allas(sor));
            }
            foreach (Allas a in allasok)
            {
                Console.WriteLine(a.ToString());
                Console.WriteLine();
            }

            //Kivel játszott Kiss Elemér? Az összes játékostárs nevét írassa ki egymás alá!
            List<string> KEJatTars = new List<string>();
            foreach (Allas a in allasok)
            {
                if(a.Vilagos == "Kiss Elemér")
                    KEJatTars.Add(a.Sotet);
                if(a.Sotet == "Kiss Elemér")
                    KEJatTars.Add(a.Vilagos);
            }

            //Legrégebbi mentés
            Allas legkorabbi = allasok[0];
            for (int i = 0; i < allasok.Count; i++)
            {
                if (allasok[i].MentesIdo < legkorabbi.MentesIdo)
                    legkorabbi = allasok[i];
            }

            //Játszott-e Kaszparov nevű játékos? Nem tudjuk, hogy ez-e a teljes neve!

            //Tanár megoldás
            int index = 0;
            while (index < allasok.Count && !(allasok[index].Vilagos.Contains("Kaszparov") || allasok[index].Sotet.Contains("Kaszparov")))
            {
                index++;
            }
            if (index < allasok.Count)
            {
                Console.WriteLine("Van Kaszparov a listában.");
            }
            else
            {
                Console.WriteLine("Nincs Kaszparov a listában.");
            }

            // Saját megoldás
            //bool vanbenne = false;
            //foreach (Allas a in allasok)
            //{
            //    if (a.Sotet.Contains("Kaszparov") || a.Vilagos.Contains("Kaszparov"))
            //    {
            //        vanbenne = true;
            //    }
            //}

            //Írassuk ki azt a mentést, amiben van világos bástya (vB) a táblán
            index = 0;
            while (index < allasok.Count && !(TartalmazErtek(allasok[index].Tabla,"vB")))
            {
                index++;
            }
            if (index < allasok.Count)
            {
                Console.WriteLine(allasok[index]);
            }
            else
            {
                Console.WriteLine("Nincs ilyen állás.");
            }


            Console.WriteLine(string.Join("\n",KEJatTars));
            Console.WriteLine($"Az első mentett állás következő játékosa: {allasok[0].KovetkezoJatekos()}");
            Console.WriteLine($"A legkorábbi mentést játszotta: {legkorabbi.Vilagos} és {legkorabbi.Sotet}");
            //Console.WriteLine($"Kaszparov nevű játékos játszott: {vanbenne}");
            Console.WriteLine(allasok[0].CompareTo(allasok[1]));
            Console.ReadLine();
        }

        /// <summary>
        /// Az adott kétdimenziós stringtömb (mátrix) tartalmazza-e az adott stringet elemként?
        /// </summary>
        /// <param name="matrix"> A kétdimenziós stringtömb </param>
        /// <param name="ertek"> A keresett elem </param>
        /// <returns> True, ha tartalmazza, false egyébként </returns>
        static bool TartalmazErtek(string[,] matrix, string ertek)
        {
            bool van = false;
            for(int i=0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j] == ertek) 
                    { 
                        van = true; 
                    }
                }
            }
            return van;
        }
    }
}