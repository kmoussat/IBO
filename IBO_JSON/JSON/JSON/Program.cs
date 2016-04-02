using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Code à tester
            string json =
                    @"[
				{ // 1er élément
				'Email': 'james@example.com',
				'Active': true,
				'CreatedDate': '2013-01-20T00:00:00Z',
				'Roles': ['User', 'Admin'],
                'Data' : [[1,0.25],[5.0,3.2]]
				}
			, 
				{ // 2e élément
				'Email': 'john@example.org',
				'Active': false,
				'CreatedDate': '2014-01-20T00:00:00Z',
				'Roles': ['User', 'Admin']
				}
			]";
            

            List<Account> account = JsonConvert.DeserializeObject<List<Account>>(json);

            Console.WriteLine(account[1].Email);
            Console.ReadKey();
            */


            WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe102");
            webClient.QueryString.Add("password", "DgeK267");
            webClient.QueryString.Add("database", "groupe102");
            webClient.QueryString.Add("collection", "sb2");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
            List<Data> datas = JsonConvert.DeserializeObject<List<Data>>(jsonString);
            Console.WriteLine(datas[1].phone);
            Console.WriteLine(datas[1].movement);
            printValues(datas[1].values);
            Console.WriteLine(datas[1].date);

            Console.ReadKey();

        }

        public static void printValues(double[,] onche)
        {
            for (int x = 0; x < onche.GetLength(0); x += 1)
            {
                for (int y = 0; y < onche.GetLength(1); y += 1)
                {
                    Console.Write(onche[x, y] + "|");
                }
                Console.Write("\n");
            }

        }
    }
}