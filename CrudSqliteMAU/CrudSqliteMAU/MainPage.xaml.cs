using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CrudSqliteMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private Product? _selectedProduct; // Pille el '?' aquí para que no chille por nulidad

        public MainPage()
        {
            InitializeComponent();
            _dbService = new LocalDbService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var products = await _dbService.GetProductsAsync();
            productsCollectionView.ItemsSource = products;
        }

        // ⚠️ Ojo al 'object? sender' en todos estos métodos, parcerito
        private async void OnSaveClicked(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(quantityEntry.Text))
            {
                await DisplayAlert("Alerta", "No sea líchigo, llene todos los campos", "OK");
                return;
            }

            if (_selectedProduct == null)
            {
                // Crear nuevo registro en la base de datos
                await _dbService.SaveProductAsync(new Product
                {
                    Name = nameEntry.Text,
                    Quantity = int.Parse(quantityEntry.Text)
                });
            }
            else
            {
                // Actualizar registro existente
                _selectedProduct.Name = nameEntry.Text;
                _selectedProduct.Quantity = int.Parse(quantityEntry.Text);
                await _dbService.SaveProductAsync(_selectedProduct);
            }

            ClearForm();
            await LoadProducts();
        }

        private async void OnDeleteClicked(object? sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button?.CommandParameter as Product;

            if (product != null)
            {
                bool answer = await DisplayAlert("Confirmar", $"¿Va a borrar {product.Name}, perro?", "Sí", "No");
                if (answer)
                {
                    await _dbService.DeleteProductAsync(product);
                    ClearForm();
                    await LoadProducts();
                }
            }
        }

        private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                _selectedProduct = e.CurrentSelection[0] as Product;
                if (_selectedProduct != null)
                {
                    nameEntry.Text = _selectedProduct.Name;
                    quantityEntry.Text = _selectedProduct.Quantity.ToString();
                    saveButton.Text = "🔄 Actualizar";
                }
            }
        }

        private void OnClearClicked(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedProduct = null;
            nameEntry.Text = string.Empty;
            quantityEntry.Text = string.Empty;
            saveButton.Text = "💾 Guardar";
            productsCollectionView.SelectedItem = null;
        }
    }
}