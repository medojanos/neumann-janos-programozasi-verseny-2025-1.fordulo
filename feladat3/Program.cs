using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace feladat3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] terkep = new int[30, 30];
            bool[,] vizTerkep = new bool[30, 30];
            int huszonegy = 0;
            int vizesNegyzetek = 0;
            int sorok = 0;
            StreamReader terkepTxt = new StreamReader("terkep.txt");
            while (!terkepTxt.EndOfStream)
            {
                string terkepSor = terkepTxt.ReadLine().Trim();
                string[] terkepSorAdatok = terkepSor.Split(' ');
                for (int i = 0; i < terkepSorAdatok.Length; i++)
                {
                    terkep[sorok, i] = int.Parse(terkepSorAdatok[i]);
                }
                sorok++;
            }
            for (int x = 0; x < terkep.GetLength(0); x++)
            {
                for (int y = 0; y < terkep.GetLength(1); y++)
                {
                    if (terkep[x, y] == 21) huszonegy++;
                    vizesNegyzetek += Vizfolyas(terkep, x, y, vizTerkep);
                }
            }
            Console.WriteLine($"a, feladat: {huszonegy}");

            Console.WriteLine($"b, feladat: {vizesNegyzetek}");

            Console.ReadKey();
        }
        static bool[,] Vizfolyas(int[,] terkep, int x, int y, bool[,] vizterkep)
        {
            if (x != 0 && terkep[x, y] > terkep[x - 1, y])
            {
                //nyugat
                vizterkep[x, y] = true;
                Vizfolyas(terkep, x - 1, y, vizterkep);
            }
            else if (y != 0 && terkep[x, y] >= terkep[x, y - 1])
            {
                //eszak
                vizterkep[x, y] = true;
                Vizfolyas(terkep, x, y - 1, vizterkep);
            }
            else if (x != 29 && terkep[x, y] >= terkep[x + 1, y])
            {
                //kelet
                vizterkep[x, y] = true;
                Vizfolyas(terkep, x + 1, y, vizterkep);
            }
            else if (y != 29 && terkep[x, y] >= terkep[x, y + 1])
            {
                //del
                vizterkep[x, y] = true;
                Vizfolyas(terkep, x, y + 1, vizterkep);
            }
            return vizterkep;
        }
    }
}
