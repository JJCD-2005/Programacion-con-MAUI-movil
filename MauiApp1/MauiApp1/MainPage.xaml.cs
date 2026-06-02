namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSaludarClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nombreEntry.Text))
            {
                mensajeLabel.Text = $"¡Hola, {nombreEntry.Text}!";
                mensajeLabel.TextColor = Colors.DarkGreen;
            }
            else
            {
                mensajeLabel.Text = "Por favor ingresa tu nombre";
                mensajeLabel.TextColor = Colors.Red;
            }
        }
    }
}
