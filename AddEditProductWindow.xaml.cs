using System;
using System.Windows;

namespace WpfApp1
{
    public partial class AddEditProductWindow : Window
    {
        public Product NewProduct { get; private set; }

        public AddEditProductWindow(Product productToEdit = null)
        {
            InitializeComponent();

            if (productToEdit != null)
            {
                NameTextBox.Text = productToEdit.Name;
                DescriptionTextBox.Text = productToEdit.Description;
                PriceTextBox.Text = productToEdit.Price.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название продукта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Пожалуйста, введите корректную цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewProduct = new Product(
                NameTextBox.Text,
                DescriptionTextBox.Text,
                price
            );

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 