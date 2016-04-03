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
    // La classe de base pour matcher la donnée json
    public class Data
    {

     
    public string phone { get; set; }
    public string movement { get; set; }
    public string date { get; set; }
    public double[,] values { get; set; }


    }
}
