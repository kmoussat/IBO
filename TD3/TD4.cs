using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using TD3_IBO;
 
namespace TD3
{
    class Program
    {
        static void Main(string[] args)
        {
 
            List<Mouvement>[] references = new List<Mouvement>[4];
            references = RecupereDonnees();
 
            decimal[][] walk = new[] {GetAverage(references, 0), GetEtendue(references, 0)};
            decimal[][] run = new[] { GetAverage(references, 1), GetEtendue(references, 1) };
            decimal[][] stationary = new[] { GetAverage(references, 2), GetEtendue(references, 2) };
            decimal[][] game = new[] { GetAverage(references, 3), GetEtendue(references, 3) };
 
            int w = Comparaison(walk);
            int r = Comparaison(run);
            int s = Comparaison(stationary);
            int g = Comparaison(game);
 
            int max = Math.Max(w, Math.Max(r, Math.Max(s, g)));
            if (max == w)
            {
                Console.WriteLine("La personne marche.");
            } else if (max == r)
            {
                Console.WriteLine("La personne court.");
            }
            else if (max == s)
            {
                Console.WriteLine("La personne est stationnaire.");
            }
            else
            {
                Console.WriteLine("La personne jouait.");
            }
 
            Console.ReadKey();
 
        }
 
        public static List<Mouvement>[] RecupereDonnees()
        {
            List<Mouvement>[] references = new List<Mouvement>[5];
            List<Mouvement> mouvements = new List<Mouvement>();
            string[] actions = {"walk", "run", "stationary", "game", ""};
 
            for (int i = 0; i < 5; i++)
            {
                WebClient webClient = new WebClient();
 
                webClient.QueryString.Add("username", "groupe49");
                webClient.QueryString.Add("password", "VuaV819");
                webClient.QueryString.Add("database", "groupe49");
                webClient.QueryString.Add("collection", "Accelerometer");
                webClient.QueryString.Add("action", actions[i]);
 
                string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
                mouvements = JsonConvert.DeserializeObject <List<Mouvement>>(jsonString);
                references[i] = mouvements;
                webClient.Dispose();
                mouvements.Clear();
            }
 
            return references;
        }
 
        public static decimal[] GetAverage(List<Mouvement>[] tab, int index)
        {
            decimal x = tab[index].ElementAt(0).measures[1].Average();
            decimal y = tab[index].ElementAt(0).measures[2].Average();
            decimal z = tab[index].ElementAt(0).measures[3].Average();
            decimal[] m = {x, y, z};
            return m;
        }
 
        public static decimal[] GetEtendue(List<Mouvement>[] tab, int index)
        {
            decimal x = Math.Abs(tab[index].ElementAt(0).measures[1].Max() - tab[index].ElementAt(0).measures[1].Min());
            decimal y = Math.Abs(tab[index].ElementAt(0).measures[2].Max() - tab[index].ElementAt(0).measures[2].Min());
            decimal z = Math.Abs(tab[index].ElementAt(0).measures[3].Max() - tab[index].ElementAt(0).measures[3].Min());
 
            decimal[] e = {x, y, z};
            return e;
        }
 
        public static int Comparaison(List<Mouvement>[] references, decimal[][] deci)
        {
            int cumul = 0;
            decimal[][] test = new[] { GetAverage(references, 4), GetEtendue(references, 4) };
 
            for (int i = 0; i < test.GetLength(1); i++)
            {
                for (int j = 0; j < test.GetLength(2); j++)
                {
                    if ((test[i][j] - deci[i][j]) < (decimal)Math.Pow(10, (-3)))
                    {
                        cumul++;
                    }
                }
            }
 
 
            return cumul;
        }
 
    }
 
}