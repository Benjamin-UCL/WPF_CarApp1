using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Car
    {
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public Car(string model, string licensePlate ) 
        { 
            this.Model = model;
            this.LicensePlate = licensePlate;
        }

        public string toString()
        {
            return $"{Model},{LicensePlate}";
        }

        public Car fromString(string carString)
        {
            string[] parts = carString.Split(',');
            if (parts.Length != 2) throw new ArgumentException("Invalid car string format");
            return new Car(parts[0], parts[1]);
        }
    }
}
