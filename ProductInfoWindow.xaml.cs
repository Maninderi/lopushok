using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class ProductInfoWindow : Window
    {
        private ObservableCollection<Product> products;

        public ProductInfoWindow()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>();
            ProductListView.ItemsSource = products;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем окно для добавления нового продукта
            var addWindow = new AddEditProductWindow();
            if (addWindow.ShowDialog() == true)
            {
                products.Add(addWindow.NewProduct);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductListView.SelectedItem as Product;
            if (selectedProduct != null)
            {
                var editWindow = new AddEditProductWindow(selectedProduct);
                if (editWindow.ShowDialog() == true)
                {
                    int index = products.IndexOf(selectedProduct);
                    products[index] = editWindow.NewProduct;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите продукт для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductListView.SelectedItem as Product;
            if (selectedProduct != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный продукт?", "Подтверждение удаления", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    products.Remove(selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите продукт для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
} 