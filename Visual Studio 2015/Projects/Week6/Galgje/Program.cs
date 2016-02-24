using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{
    class Program
    {
        private const string WOORDENURL = "woorden.txt";
        static void Main(string[] args)
        {
#region Properties
            Random rnd = new Random();
            string zoekWoord;
            List<string> woorden = new List<string>();
            int aantalFoutenLetters = 0;
            List<char> ingevoerdeletters = new List<char>();
#endregion
            #region Setup game
            using (StreamReader reader = new StreamReader(WOORDENURL))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    LeesWoorden(line, ref woorden);
                }
            }
            zoekWoord = woorden[rnd.Next(woorden.Count)];
            Console.WriteLine(zoekWoord);
#endregion
            Console.WriteLine("na enter begint het spel");
            Console.ReadLine();
            Console.Clear();

            while (!Toonwoord(zoekWoord,ingevoerdeletters)&& aantalFoutenLetters != 8)
            {
                Console.WriteLine("ingevoerde letters:"+String.Concat(ingevoerdeletters));
                Console.WriteLine("Aantal pogingen over: "+ aantalFoutenLetters);
                Console.Write("geef een letter:");
                ingevoerdeletters.Add(Console.ReadKey().KeyChar);
                aantalFoutenLetters = ToonIngevoerdeLetters(zoekWoord, ingevoerdeletters);

            }
            if (aantalFoutenLetters == 8)
            {
                Console.WriteLine(" het woord  was " + zoekWoord);
            }
            else
            {
                Console.WriteLine("Gewonnen");
            }
            
            Console.ReadLine();
        }

        private static int ToonIngevoerdeLetters(string zoekWoord, List<char> ingevoerdeletters)
        {
            return ingevoerdeletters.Count(x => !zoekWoord.Any(y => y == x));
        }

        private static bool Toonwoord(string zoekWoord, List<char> ingevoerdeletters)
        {
            bool gevonden = true;
            Console.WriteLine();
            for (int i = 0; i < zoekWoord.Length; i++)
            {
                
                char letter = zoekWoord[i];
                if (ingevoerdeletters.Contains(letter))
                {
                    Console.Write(" {0}",letter);
                }
                else
                {
                    Console.Write(" {0}", '.');
                    gevonden = false;
                }
            }
            Console.WriteLine();
            return (gevonden && ingevoerdeletters.Count != 0);
        }

        private static void LeesWoorden(string woord, ref List<string> woorden)
        {
            if (woord.Length < 3)
            {
                return;
            }
            woorden.Add(woord);
        }
    }
}
