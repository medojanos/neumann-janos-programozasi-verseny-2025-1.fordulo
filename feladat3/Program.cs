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
            int[,] terkep = new int[30,30];
            int huszonegy = 0;
            int vizesNegyzetek = 0;
            int sorok = 0;
            StreamReader terkepTxt = new StreamReader("terkep.txt");
            while (!terkepTxt.EndOfStream) {
                string terkepSor = terkepTxt.ReadLine().Trim();
                string[] terkepSorAdatok = terkepSor.Split(' ');
                for (int i = 0; i < terkepSorAdatok.Length; i++)
                {
                    terkep[sorok, i] = int.Parse(terkepSorAdatok[i]);
                }
                sorok++;
            }
            for (int x = 0; x < terkep.GetLength(0); x++) {
                for (int y = 0; y < terkep.GetLength(1); y++) { 
                    if (terkep[x,y] == 21) huszonegy++;

                }
            }
            Console.WriteLine($"a, feladat: {huszonegy}");

            Console.WriteLine($"b, feladat: {vizesNegyzetek}");

            Console.ReadKey();
        }
    }
}
