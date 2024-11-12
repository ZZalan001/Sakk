using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk
{
    public class Allas
    {
        DateTime mentesIdo;
        /// <summary>
        /// Az állás mentésének adatai
        /// </summary>
        /// <param name="id"> A játék azonosítója </param>
        /// <param name="vilagos"> A világos bábuk játékosának neve </param>
        /// <param name="sotet"> A sötét bábuk játékosának neve </param>
        /// <param name="tabla"> 8x8 as string tömb, benne a bábuk pl vH --> világos huszár </param>
        /// <param name="vilagosJon"> true, ha a világos játékos jön </param>
        /// <param name="mentesIdo"> egy dátum-idő szövegesen, ha 0 vagy kihagyjuk akkor az aktuális időpontot menti</param>
        public Allas(int id, string vilagos, string sotet, string[,] tabla, bool vilagosJon, string mentesIdo = "0")
        {
            Id = id;
            Vilagos = vilagos;
            Sotet = sotet;
            Tabla = tabla;
            VilagosJon = vilagosJon;
            MentesIdo = DateTime.Parse(mentesIdo);
        }

        public int Id {  get; set; }
        public string Vilagos { get; set; }
        public string Sotet { get; set; }
        public string[,] Tabla { get; set; }
        public bool VilagosJon { get; set; }
        public DateTime MentesIdo {
            get { return mentesIdo; }
            set {
                if (value == DateTime.Parse("0"))
                {
                    mentesIdo = DateTime.Now;
                }
                else
                {
                    mentesIdo = value;
                }
            } 
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Játék azonosítója: {Id}\n");
            sb.Append($"Mentési idő: {MentesIdo.ToString()}\n");
            sb.Append($"Világos játékos: {Vilagos}\n");
            sb.Append($"Sötét játékos: {Sotet}\n");
            string kovetkezo = VilagosJon ? "világos" : "sötét";
            sb.Append($"Következő játékos: {kovetkezo}");
            return sb.ToString();
        }
    }
}
