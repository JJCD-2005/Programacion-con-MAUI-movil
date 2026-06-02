namespace ListaTareasMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Aquí le conectamos el bindeo para que el XAML no quede sordo, marica
            BindingContext = new MainViewModel();
        }
    }
}