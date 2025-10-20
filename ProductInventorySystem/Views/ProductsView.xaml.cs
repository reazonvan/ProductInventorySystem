using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProductInventorySystem.Models;
using ProductInventorySystem.Services;

namespace ProductInventorySystem.Views
{
    /// <summary>
    /// Модуль "Товары" - добавление, редактирование и удаление товаров
    /// Роль: Разработчик 1
    /// </summary>
    public partial class ProductsView : UserControl
    {
        private ProductService _productService;

        public ProductsView()
        {
            InitializeComponent();
            _productService = ProductService.Instance;
            LoadProducts();
        }

        /// <summary>
        /// Загрузить список товаров
        /// </summary>
        private void LoadProducts()
        {
            dgProducts.ItemsSource = _productService.GetAllProducts();
        }

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProductDialog();
            if (dialog.ShowDialog() == true)
            {
                _productService.AddProduct(dialog.Product);
                LoadProducts();
            }
        }

        /// <summary>
        /// Редактировать выбранный товар
        /// </summary>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар для редактирования.", 
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedProduct = dgProducts.SelectedItem as Product;
            var dialog = new ProductDialog(selectedProduct);
            if (dialog.ShowDialog() == true)
            {
                _productService.UpdateProduct(dialog.Product);
                LoadProducts();
            }
        }

        /// <summary>
        /// Удалить выбранный товар
        /// </summary>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.", 
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный товар?", 
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var selectedProduct = dgProducts.SelectedItem as Product;
                _productService.DeleteProduct(selectedProduct.ProductID);
                LoadProducts();
            }
        }
    }
}

