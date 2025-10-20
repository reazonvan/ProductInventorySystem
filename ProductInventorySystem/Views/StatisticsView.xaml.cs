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
using ProductInventorySystem.Services;
using ProductInventorySystem.Models;

namespace ProductInventorySystem.Views
{
    /// <summary>
    /// Модуль "Статистика" - подсчёт общей суммы, средней цены по категории
    /// Роль: Разработчик 2
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        private ProductService _productService;

        public StatisticsView()
        {
            InitializeComponent();
            _productService = ProductService.Instance;
            LoadStatistics();
            LoadCategories();
        }

        /// <summary>
        /// Загрузить общую статистику
        /// </summary>
        private void LoadStatistics()
        {
            var stats = _productService.GetStatistics();
            txtTotalProducts.Text = stats.TotalProducts.ToString();
            txtAveragePrice.Text = $"{stats.AveragePrice:F2} руб.";
            txtTotalValue.Text = $"{stats.TotalValue:F2} руб.";
        }

        /// <summary>
        /// Загрузить список категорий
        /// </summary>
        private void LoadCategories()
        {
            var categories = _productService.GetCategories();
            cmbCategories.ItemsSource = categories;
            if (categories.Count > 0)
            {
                cmbCategories.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Обработчик изменения выбранной категории
        /// </summary>
        private void cmbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCategories.SelectedItem != null)
            {
                LoadCategoryStatistics(cmbCategories.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// Загрузить статистику по категории
        /// </summary>
        private void LoadCategoryStatistics(string category)
        {
            var stats = _productService.GetStatisticsByCategory(category);
            
            txtCategoryProducts.Text = stats.TotalProducts.ToString();
            txtCategoryAveragePrice.Text = $"{stats.AveragePrice:F2} руб.";
            txtCategoryTotalValue.Text = $"{stats.TotalValue:F2} руб.";
            
            categoryStatsPanel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Обновить статистику
        /// </summary>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadStatistics();
            LoadCategories();
            
            if (cmbCategories.SelectedItem != null)
            {
                LoadCategoryStatistics(cmbCategories.SelectedItem.ToString());
            }
        }
    }
}

