using System;

namespace ProductInventorySystem.Models
{
    /// <summary>
    /// Сущность "Товар"
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор товара (PK)
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }

        public Product()
        {
            Name = string.Empty;
            Category = string.Empty;
        }

        public Product(int id, string name, string category, decimal price, int quantity)
        {
            ProductID = id;
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }
}

