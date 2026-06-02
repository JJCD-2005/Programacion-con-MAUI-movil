namespace ClimaAppMAUI
{
    public partial class MainPage : ContentPage
    {
        private WeatherData weatherData;

        public MainPage()
        {
            InitializeComponent();

            // Sembramos los datos de ejemplo iniciales
            weatherData = new WeatherData
            {
                Temperature = 24.5,
                Humidity = 65,
                Condition = "Parcialmente nublado"
            };

            // Asignamos el BindingContext para que el XAML sepa de dónde heredar las propiedades
            this.BindingContext = weatherData;
        }

        private void OnActualizarClicked(object sender, EventArgs e)
        {
            var random = new Random();

            // Generamos datos aleatorios para simular el clima de Pereira
            weatherData.Temperature = random.Next(15, 35) + random.NextDouble();
            weatherData.Humidity = random.Next(40, 90);

            string[] conditions = { "Soleado", "Parcial", "Nublado", "Lluvioso" };
            weatherData.Condition = conditions[random.Next(conditions.Length)];
        }
    }
}