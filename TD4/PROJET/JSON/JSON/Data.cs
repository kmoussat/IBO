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
    public class Data
    {
        public string phone { get; set; } // Le nom des propriétés est strictement identique à la donnée json qui sera matchée
        public string movement { get; set; }
        public double[,] values { get; set; }
        public int[] time { get; set; }
        public double[] x { get; set; }
        public double[] y { get; set; }
        public double[] z { get; set; }
        public string date { get; set; }

        public Data(string phone, string movement, double[,] values, string date)
        {
            this.phone = phone;
            this.movement = movement;
            this.values = values;
            this.date = date;
            this.time = new int[values.GetLength(0)];
            this.x = new double[values.GetLength(0)];
            this.y = new double[values.GetLength(0)];
            this.z = new double[values.GetLength(0)];
        }
    }
}