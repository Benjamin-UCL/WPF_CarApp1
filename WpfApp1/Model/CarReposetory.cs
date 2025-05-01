using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class CarReposetory
    {
        private string _path;

        public CarReposetory(string path)
        {
            _path = path;
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }

        public IEnumerable<Car> GetAll()
        {
            return File.ReadAllLines(_path)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(','))
                .Select(parts => new Car(parts[0], parts[1]))
                .ToList();
        }

        public void Add(Car car)
        {
            string carString = car.toString();
            File.AppendAllText(_path, carString + Environment.NewLine);
        }

    }
}
