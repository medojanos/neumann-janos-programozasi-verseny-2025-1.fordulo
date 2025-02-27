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
            int huszonegy = 0; //a, feladat
            int vizesNegyzetek = 0; //b, feladat
            int tiznelKisebb = 0; //c, feladat
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
                    if (terkep[x, y] == 21) {
                        huszonegy++;
                        Vizfolyas(x, y);
                    } 
                }
            }
            Console.WriteLine($"a, feladat: {huszonegy}");

            void Vizfolyas(int x, int y)
            {
                vizTerkep[x, y] = true;
                if (x > 0 && terkep[x, y] >= terkep[x - 1, y] && vizTerkep[x - 1, y] != true)
                {
                    //nyugat
                    vizTerkep[x, y] = true;
                    Vizfolyas(x - 1, y);
                }
                if (y > 0 && terkep[x, y] >= terkep[x, y - 1] && vizTerkep[x, y - 1] != true)
                {
                    //eszak
                    vizTerkep[x, y] = true;
                    Vizfolyas(x, y - 1);
                }
                if (x < 29 && terkep[x, y] >= terkep[x + 1, y] && vizTerkep[x + 1, y] != true)
                {
                    //kelet
                    vizTerkep[x, y] = true;
                    Vizfolyas(x + 1, y);
                }
                if (y < 29 && terkep[x, y] >= terkep[x, y + 1] && vizTerkep[x, y + 1] != true)
                {
                    //del
                    vizTerkep[x, y] = true;
                    Vizfolyas(x, y + 1);
                }
            }
            for (int x = 0; x < vizTerkep.GetLength(0); x++)
            {
                for (int y = 0; y < vizTerkep.GetLength(1); y++)
                {
                    if (vizTerkep[x, y] == true)
                    {
                        vizesNegyzetek++;
                        if (terkep[x, y] < 10) tiznelKisebb++;
                    }
                }
            }
            Console.WriteLine($"b, feladat: {vizesNegyzetek}");

            Console.WriteLine($"c, feladat: {tiznelKisebb}");

            Console.ReadKey();
        }
    }
}
