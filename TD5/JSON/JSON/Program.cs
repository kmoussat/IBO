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
            double[] referencestill = SetReferenceStill();

            /*
            Rappel r1 = new Rappel(rappelImpl1); function_rappel(2, r1);
            Rappel r2 = new Rappel(rappelImpl2); function_rappel(2, r2);

            Precision p1 = new Precision(preImpl1); function_precision(2, p1);
            Precision p2 = new Precision(preImpl2); function_precision(2, p2);
            */

            //DOWNLOADING DATA TO TEST
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe102");
            webClient.QueryString.Add("password", "DgeK267");
            webClient.QueryString.Add("database", "groupe102");
            webClient.QueryString.Add("collection", "referencerun");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");

            try
            {


                List<Data> datas = JsonConvert.DeserializeObject<List<Data>>(jsonString);
                Console.WriteLine("DETECTING MOVEMENT ON DATA");
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey();
                Console.WriteLine();

                


                //TESTING DATA
                DetectionResult Resultats = Detectmov(datas[0],referencestill, referencewalk, referencerun);

                //rappel & precision
                double rappel = ( System.Convert.ToDouble(Resultats.nbmovementdetected) / System.Convert.ToDouble(Resultats.numberofmovements));
                double precision = (System.Convert.ToDouble(Resultats.numberofmovements) / System.Convert.ToDouble(Resultats.numberofmovements));

                //PRINTING RESULTS
                Console.WriteLine("Device used is : "+Resultats.phone);
                Console.WriteLine("Date : "+Resultats.date);
                
                Console.WriteLine("Movement : " + Resultats.movementdetected);
                Console.WriteLine("Number of movements detected : "+Resultats.numberofmovements);
                Console.WriteLine("Rappel : " + rappel);
                Console.WriteLine("Precision : " + precision);

                Console.ReadKey();
            }
            
            catch (Exception e)
            {

                Console.WriteLine(e);
                Console.ReadKey();
            }
            

            

        }

        /*
        public delegate void Rappel(int c);

        public static void rappelImpl1(int c) { Console.WriteLine("{0}", c); }
        public static void rappelImpl2(int c) { Console.WriteLine("*{0} *", c); }

        public static void function_rappel(int d, Rappel rappel)
        {
            

        }

        public delegate void Precision(int c);

        public static void preImpl1(int c) { Console.WriteLine("{0}", c); }
        public static void preImpl2(int c) { Console.WriteLine("*{0} *", c); }

        public static void function_precision(int d, Precision precision)
        {
            
        }
        */


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

        public static double[] SetReferenceStill()
        {

            WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe102");
            webClient.QueryString.Add("password", "DgeK267");
            webClient.QueryString.Add("database", "groupe102");
            webClient.QueryString.Add("collection", "referencestill");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
            List<Data> datas = JsonConvert.DeserializeObject<List<Data>>(jsonString);

            //ACCELERATION AND TIME VALUES SEPARATION IN TEST.TIME, TEST.X, TEST.Y, TEST.Z
            Data refstill = new Data(datas[0].phone, datas[0].movement, datas[0].values, datas[0].date);


            double mx = Math.Abs(refstill.x.Average());
            double my = Math.Abs(refstill.y.Average());
            double mz = Math.Abs(refstill.z.Average());
            double amp = refstill.x.Max() - refstill.x.Min();
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
            Data refwalk = new Data(datas[0].phone, datas[0].movement, datas[0].values, datas[0].date);


            double mx = Math.Abs(refwalk.x.Average());
            double my = Math.Abs(refwalk.y.Average());
            double mz = Math.Abs(refwalk.z.Average());
            double ampx = refwalk.x.Max() - refwalk.x.Min();
            double ampy = refwalk.y.Max() - refwalk.y.Min();
            double ampz = refwalk.z.Max() - refwalk.z.Min();
            double[] result = new[] {mx, my, mz, ampx, ampy, ampz};
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
            Data refrun = new Data(datas[0].phone, datas[0].movement, datas[0].values, datas[0].date);


            double mx = Math.Abs(refrun.x.Average());
            double my = Math.Abs(refrun.y.Average());
            double mz = Math.Abs(refrun.z.Average());
            double ampx = refrun.x.Max() - refrun.x.Min();
            double ampy = refrun.y.Max() - refrun.y.Min();
            double ampz = refrun.z.Max() - refrun.z.Min();
            double[] result = new[] { mx, my, mz, ampx, ampy, ampz };
            return result;

        }

        public static DetectionResult Detectmov(Data data, double[] referencenomvmt, double[] referencewalk, double[] referencerun)
        {
            //NUMBER OF MOVEMENTS DETECTED
            int n = 0;

            //ACCELERATION AND TIME VALUES SEPARATION IN TEST.TIME, TEST.X, TEST.Y, TEST.Z
            Data test= new Data(data.phone,data.movement,data.values,data.date);

            double mx = Math.Abs(test.x.Average());
            double my = Math.Abs(test.y.Average());
            double mz = Math.Abs(test.z.Average());
            double mampstill = referencenomvmt[3];
            double[] mampwalk = new[] {referencewalk[3],referencewalk[4], referencewalk[5]};
            double[] mamprun = new[] { referencerun[3], referencerun[4], referencerun[5]};

            //MOVEMENT TYPE DETECTION
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


            //NUMBER OF MOVEMENTS DETECTION
            for (int i = 0; i < test.time.Length; i++)
            {
                for (int j = i+1; j < test.time.Length; j++)
                {
                    if (test.time[j] - test.time[i] > 800 && test.time[j] - test.time[i] < 900)
                    {
                        if (test.movement == "still")
                            {
                                n = 0;
                                break;
                            }

                        if (test.movement == "walk")
                        {
                            if (test.x[j] - test.x[i] > mampwalk[0]/1.3 ||
                                test.y[j] - test.y[i] > mampwalk[1]/1.3 ||
                                test.z[j] - test.z[i] > mampwalk[2]/1.3)
                            {
                                n++;
                            }
                        }
                        if (test.movement == "run")
                        {
                            if (test.x[j] - test.x[i] > mamprun[0] / 1.3 ||
                                test.y[j] - test.y[i] > mamprun[1] / 1.3 ||
                                test.z[j] - test.z[i] > mamprun[2] / 1.3)
                            {
                                n++;
                            }
                        }

                    }
                }

            }


            
            DetectionResult resultat = new DetectionResult(test.phone, test.movement,n, test.date, test.movement.Count());

            return resultat;
        }

    }
}