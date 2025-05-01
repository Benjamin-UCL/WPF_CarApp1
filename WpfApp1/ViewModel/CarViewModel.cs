using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp1.Model;
using System.Windows.Input;
using System.Windows;

namespace WpfApp1.ViewModel
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private string model;
        private string licensePlate;
        CarReposetory carRepo = new CarReposetory("./Car.txt");

        public string Model
        {
            get => model;
            set { model = value; OnPropertyChanged(); }
        }

        public string LicensePlate
        {
            get => licensePlate;
            set { licensePlate = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Car> Cars { get; }// = new ObservableCollection<Car>();

        public ICommand AddCarCommand { get; }

        public CarViewModel()
        {
            AddCarCommand = new RelayCommand(AddCar, CanAddCar);

            Cars = new ObservableCollection<Car>(carRepo.GetAll());
        }

        private void AddCar()
        {   
            Car input = new Car(Model, LicensePlate);
            Cars.Add(input);
            carRepo.Add(input);
            Model = string.Empty;
            LicensePlate = string.Empty;
        }

        private bool CanAddCar()
        {
            return !string.IsNullOrWhiteSpace(Model) && !string.IsNullOrWhiteSpace(LicensePlate);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
