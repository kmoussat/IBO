using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;



namespace JSON
{
    public class Program
    {


        public static void Main(string[] args)
        {
            double[] referencewalk = SetReferencewalk();
            double[] referencerun = SetReferencerun();
            double[] referencenomvmt = SetReferencenomvmt();

            WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe102");
            webClient.QueryString.Add("password", "DgeK267");
            webClient.QueryString.Add("database", "groupe102");
            webClient.QueryString.Add("collection", "sb2");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
            List<Data> datas = JsonConvert.DeserializeObject<List<Data>>(jsonString);

            Rappel r1 = new Rappel(rappelImpl1); function_rappel(2, r1);
            Rappel r2 = new Rappel(rappelImpl2); function_rappel(2, r2);

            Precision p1 = new Precision(preImpl1); function_precision(2, p1);
            Precision p2 = new Precision(preImpl2); function_precision(2, p2);

            detectpas(datas[0],referencenomvmt, referencewalk, referencerun);
            Console.ReadKey();

        }

        public delegate void Rappel(int c);

        public static void rappelImpl1(int c) { Console.WriteLine("{0}", c); }
        public static void rappelImpl2(int c) { Console.WriteLine("*{0} *", c); }

        public static void function_rappel(int d, Rappel rappel)
        {
            /* Fonction rappel Appatenance*/

        }

        public delegate void Precision(int c);

        public static void preImpl1(int c) { Console.WriteLine("{0}", c); }
        public static void preImpl2(int c) { Console.WriteLine("*{0} *", c); }

        public static void function_precision(int d, Precision precision)
        {
            /* Fonction precision Attribution*/
        }



        public static void printValues(double[,] onche)
        {
            for (int x = 0; x < onche.GetLength(0); x += 1)
            {
                for (int y = 0; y < onche.GetLength(1); y += 1)
                {
                    Console.Write(onche[x, y]);
                }
                Console.Write("\n");
            }

        }

        public static double[] SetReferencenomvmt()
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe102");
            webClient.QueryString.Add("password", "DgeK267");
            webClient.QueryString.Add("database", "groupe102");
            webClient.QueryString.Add("collection", "referencenomvmt");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
            List<Data> datas = JsonConvert.DeserializeObject<List<Data>>(jsonString);

            //ACCELERATION AND TIME VALUES SEPARATION IN TEST.TIME, TEST.X, TEST.Y, TEST.Z
            Data test = new Data(datas[0].phone, datas[0].movement, datas[0].values, datas[0].date);
            //TIME ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.time[i] = (int)datas[0].values[i, 0];
            }

            //X ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.x[i] = datas[0].values[i, 1];
            }

            //Y ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.y[i] = datas[0].values[i, 2];
            }

            //Z ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.z[i] = datas[0].values[i, 3];
            }

            double mx = Math.Abs(test.x.Average());
            double my = Math.Abs(test.y.Average());
            double mz = Math.Abs(test.z.Average());
            double amp = test.x.Max() - test.x.Min();
            double[] result = new[] { mx, my, mz, amp };
            return result;



        }

        public static double[] SetReferencewalk()
        {

            
         
                WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe102");
            webClient.QueryString.Add("password", "DgeK267");
            webClient.QueryString.Add("database", "groupe102");
            webClient.QueryString.Add("collection", "referencewalk");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
            List<Data> datas = JsonConvert.DeserializeObject<List<Data>>(jsonString);

                //ACCELERATION AND TIME VALUES SEPARATION IN TEST.TIME, TEST.X, TEST.Y, TEST.Z
                Data test = new Data(datas[0].phone, datas[0].movement, datas[0].values, datas[0].date);

                //TIME ARRAY
                for (int i = 0; i < datas[0].values.GetLength(0); i++)
                {
                    test.time[i] = (int)datas[0].values[i, 0];
                }

                //X ARRAY
                for (int i = 0; i < datas[0].values.GetLength(0); i++)
                {
                    test.x[i] = datas[0].values[i, 1];
                }

                //Y ARRAY
                for (int i = 0; i < datas[0].values.GetLength(0); i++)
                {
                    test.y[i] = datas[0].values[i, 2];
                }

                //Z ARRAY
                for (int i = 0; i < datas[0].values.GetLength(0); i++)
                {
                    test.z[i] = datas[0].values[i, 3];
                }

                double mx = Math.Abs(test.x.Average());
                double my = Math.Abs(test.y.Average());
                double mz = Math.Abs(test.z.Average());
                double amp = test.x.Max() - test.x.Min();
                double[] result = new[] { mx, my, mz, amp };
                return result;
           

        }

        public static double[] SetReferencerun()
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe102");
            webClient.QueryString.Add("password", "DgeK267");
            webClient.QueryString.Add("database", "groupe102");
            webClient.QueryString.Add("collection", "referencerun");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
            List<Data> datas = JsonConvert.DeserializeObject<List<Data>>(jsonString);

            //ACCELERATION AND TIME VALUES SEPARATION IN TEST.TIME, TEST.X, TEST.Y, TEST.Z
            Data test = new Data(datas[0].phone, datas[0].movement, datas[0].values, datas[0].date);
            //TIME ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.time[i] = (int)datas[0].values[i, 0];
            }

            //X ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.x[i] = datas[0].values[i, 1];
            }

            //Y ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.y[i] = datas[0].values[i, 2];
            }

            //Z ARRAY
            for (int i = 0; i < datas[0].values.GetLength(0); i++)
            {
                test.z[i] = datas[0].values[i, 3];
            }

            double mx = Math.Abs(test.x.Average());
            double my = Math.Abs(test.y.Average());
            double mz = Math.Abs(test.z.Average());
            double amp = test.x.Max() - test.x.Min();
            double[] result = new[] { mx, my, mz, amp };
            return result;




        }

        public static void detectpas(Data data, double[] referencenomvmt, double[] referencewalk, double[] referencerun)
        {
            //ACCELERATION AND TIME VALUES SEPARATION IN TEST.TIME, TEST.X, TEST.Y, TEST.Z
            Data test= new Data(data.phone,data.movement,data.values,data.date);
            //TIME ARRAY
            for (int i = 0; i < data.values.GetLength(0); i++)
            {
                test.time[i] = (int) data.values[i, 0];
            }

            //X ARRAY
            for (int i = 0; i < data.values.GetLength(0); i++)
            {
                test.x[i] = data.values[i, 1];
            }

            //Y ARRAY
            for (int i = 0; i < data.values.GetLength(0); i++)
            {
                test.y[i] = data.values[i, 2];
            }

            //Z ARRAY
            for (int i = 0; i < data.values.GetLength(0); i++)
            {
                test.z[i] = data.values[i, 3];
            }
            
            double mx = Math.Abs(test.x.Average());
            double my = Math.Abs(test.y.Average());
            double mz = Math.Abs(test.z.Average());


            if (mx < referencenomvmt[0] &&
                my < referencenomvmt[1] &&
                mz < referencenomvmt[2])
            {
                test.movement = "still";
            }

            if (mx > referencenomvmt[0] && mx < referencewalk[0] &&
                my > referencenomvmt[1] && my < referencewalk[1] &&
                mz > referencenomvmt[2] && mz < referencewalk[2])
            {
                test.movement = "walk";
            }


            if (mx > referencewalk[0] && mx < referencerun[0] &&
                my > referencewalk[1] && my < referencerun[1] &&
                mz > referencewalk[2] && mz < referencerun[2])
            {
                test.movement = "run";
            }




        }



    }
}