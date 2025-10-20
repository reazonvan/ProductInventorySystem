using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProductInventorySystem.Models;

namespace ProductInventorySystem.Services
{
    /// <summary>
    /// Сервис для управления товарами
    /// </summary>
    public class ProductService
    {
        private static ProductService _instance;
        private ObservableCollection<Product> _products;
        private int _nextId;

        public static ProductService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductService();
                }
                return _instance;
            }
        }

        private ProductService()
        {
            _products = new ObservableCollection<Product>();
            _nextId = 1;
            InitializeSampleData();
        }

        /// <summary>
        /// Получить все товары
        /// </summary>
        public ObservableCollection<Product> GetAllProducts()
        {
            return _products;
        }

        /// <summary>
        /// Добавить товар
        /// </summary>
        public void AddProduct(Product product)
        {
            product.ProductID = _nextId++;
            _products.Add(product);
        }

        /// <summary>
        /// Обновить товар
        /// </summary>
        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Category = product.Category;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
            }
        }

        /// <summary>
        /// Удалить товар
        /// </summary>
        public void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        /// <summary>
        /// Поиск товаров по названию
        /// </summary>
        public List<Product> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return _products.ToList();

            return _products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        /// <summary>
        /// Поиск товаров по категории
        /// </summary>
        public List<Product> SearchByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return _products.ToList();

            return _products.Where(p => p.Category.ToLower().Contains(category.ToLower())).ToList();
        }

        /// <summary>
        /// Получить уникальные категории
        /// </summary>
        public List<string> GetCategories()
        {
            return _products.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();
        }

        /// <summary>
        /// Получить статистику по всем товарам
        /// </summary>
        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            stats.TotalProducts = _products.Sum(p => p.Quantity);
            stats.AveragePrice = _products.Any() ? _products.Average(p => p.Price) : 0;
            stats.TotalValue = _products.Sum(p => p.Price * p.Quantity);
            return stats;
        }

        /// <summary>
        /// Получить статистику по категории
        /// </summary>
        public Statistics GetStatisticsByCategory(string category)
        {
            var productsInCategory = _products.Where(p => p.Category == category).ToList();
            var stats = new Statistics();
            stats.TotalProducts = productsInCategory.Sum(p => p.Quantity);
            stats.AveragePrice = productsInCategory.Any() ? productsInCategory.Average(p => p.Price) : 0;
            stats.TotalValue = productsInCategory.Sum(p => p.Price * p.Quantity);
            return stats;
        }

        /// <summary>
        /// Инициализация тестовыми данными
        /// </summary>
        private void InitializeSampleData()
        {
            AddProduct(new Product { Name = "Ноутбук Lenovo", Category = "Электроника", Price = 45000, Quantity = 5 });
            AddProduct(new Product { Name = "Смартфон Samsung", Category = "Электроника", Price = 25000, Quantity = 10 });
            AddProduct(new Product { Name = "Клавиатура Logitech", Category = "Аксессуары", Price = 2500, Quantity = 15 });
            AddProduct(new Product { Name = "Мышь Razer", Category = "Аксессуары", Price = 3500, Quantity = 20 });
            AddProduct(new Product { Name = "Монитор Dell", Category = "Электроника", Price = 15000, Quantity = 8 });
        }
    }
}

