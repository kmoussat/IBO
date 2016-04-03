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
    public class Account
    {
        public string Email { get; set; } // Le nom des propriétés est strictement identique à la donnée json qui sera matchée
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string[] Roles { get; set; }
        public double[,] Data { get; set; }


    }


}