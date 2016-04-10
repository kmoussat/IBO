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
    public class DetectionResult
    {
        public string phone { get; set; } // Le nom des propriétés est strictement identique à la donnée json qui sera matchée
        public string movementdetected { get; set; }
        public int numberofmovements { get; set; }
        public string date { get; set; }
        public int nbmovementdetected { get; set; }

        public DetectionResult(string phone, string movementdetected, int numberofmovements, string date, int nbmovementdetected)
        {
            this.phone = phone;
            this.movementdetected = movementdetected;
            this.numberofmovements = numberofmovements;
            this.date = date;
            this.nbmovementdetected = movementdetected.Count(); //pour les calculs de rappel et préscision
        }

    }
}
