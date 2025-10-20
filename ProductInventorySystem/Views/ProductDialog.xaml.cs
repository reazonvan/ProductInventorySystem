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
using System.Windows.Shapes;
using ProductInventorySystem.Models;

namespace ProductInventorySystem.Views
{
    /// <summary>
    /// Диалоговое окно для добавления/редактирования товара
    /// </summary>
    public partial class ProductDialog : Window
    {
        public Product Product { get; private set; }

        public ProductDialog()
        {
            InitializeComponent();
            Product = new Product();
            Title = "Добавить товар";
        }

        public ProductDialog(Product product)
        {
            InitializeComponent();
            Product = new Product
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                Quantity = product.Quantity
            };
            Title = "Редактировать товар";
            LoadProduct();
        }

        private void LoadProduct()
        {
            txtName.Text = Product.Name;
            txtCategory.Text = Product.Category;
            txtPrice.Text = Product.Price.ToString();
            txtQuantity.Text = Product.Quantity.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Введите категорию товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Введите корректное количество.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product.Name = txtName.Text.Trim();
            Product.Category = txtCategory.Text.Trim();
            Product.Price = price;
            Product.Quantity = quantity;

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

