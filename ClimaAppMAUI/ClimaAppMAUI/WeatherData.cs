using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClimaAppMAUI
{
    public class WeatherData : INotifyPropertyChanged
    {
        private double temperature;
        private int humidity;
        private string condition;

        public double Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                OnPropertyChanged();
            }
        }

        public int Humidity
        {
            get => humidity;
            set
            {
                humidity = value;
                OnPropertyChanged();
            }
        }

        public string Condition
        {
            get => condition;
            set
            {
                condition = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}