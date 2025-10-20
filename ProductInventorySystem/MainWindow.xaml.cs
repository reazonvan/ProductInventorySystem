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
using ProductInventorySystem.Views;

namespace ProductInventorySystem
{
    /// <summary>
    /// Главное окно приложения с навигацией между модулями
    /// Роль: Лидер команды
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // По умолчанию открываем модуль "Товары"
            ShowProductsModule();
        }

        /// <summary>
        /// Переключение на модуль "Товары"
        /// </summary>
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            ShowProductsModule();
        }

        /// <summary>
        /// Переключение на модуль "Статистика"
        /// </summary>
        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            ShowStatisticsModule();
        }

        /// <summary>
        /// Переключение на модуль "Поиск"
        /// </summary>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ShowSearchModule();
        }

        private void ShowProductsModule()
        {
            ContentArea.Content = new ProductsView();
        }

        private void ShowStatisticsModule()
        {
            ContentArea.Content = new StatisticsView();
        }

        private void ShowSearchModule()
        {
            ContentArea.Content = new SearchView();
        }
    }
}
