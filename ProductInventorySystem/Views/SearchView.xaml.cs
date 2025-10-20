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
    /// Модуль "Поиск" - поиск товаров по названию или категории
    /// Роль: Разработчик 3
    /// </summary>
    public partial class SearchView : UserControl
    {
        private ProductService _productService;

        public SearchView()
        {
            InitializeComponent();
            _productService = ProductService.Instance;
            LoadCategories();
            ShowAllProducts();
        }

        /// <summary>
        /// Загрузить список категорий
        /// </summary>
        private void LoadCategories()
        {
            var categories = _productService.GetCategories();
            categories.Insert(0, "Все категории");
            cmbSearchCategory.ItemsSource = categories;
            cmbSearchCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Поиск по названию
        /// </summary>
        private void btnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txtSearchName.Text.Trim();
            var results = _productService.SearchByName(searchText);
            DisplayResults(results);
        }

        /// <summary>
        /// Поиск по категории
        /// </summary>
        private void btnSearchByCategory_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSearchCategory.SelectedItem == null)
                return;

            var category = cmbSearchCategory.SelectedItem.ToString();
            
            List<Product> results;
            if (category == "Все категории")
            {
                results = _productService.GetAllProducts().ToList();
            }
            else
            {
                results = _productService.SearchByCategory(category);
            }
            
            DisplayResults(results);
        }

        /// <summary>
        /// Сбросить фильтры и показать все товары
        /// </summary>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtSearchName.Text = string.Empty;
            cmbSearchCategory.SelectedIndex = 0;
            ShowAllProducts();
        }

        /// <summary>
        /// Показать все товары
        /// </summary>
        private void ShowAllProducts()
        {
            var allProducts = _productService.GetAllProducts().ToList();
            DisplayResults(allProducts);
        }

        /// <summary>
        /// Отобразить результаты поиска
        /// </summary>
        private void DisplayResults(List<Product> results)
        {
            dgSearchResults.ItemsSource = results;
            txtResultCount.Text = $"({results.Count} товаров)";
        }
    }
}

