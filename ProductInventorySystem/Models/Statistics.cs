namespace ProductInventorySystem.Models
{
    /// <summary>
    /// Сущность "Статистика"
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Общее количество товаров
        /// </summary>
        public int TotalProducts { get; set; }

        /// <summary>
        /// Средняя цена по категории
        /// </summary>
        public decimal AveragePrice { get; set; }

        /// <summary>
        /// Общая сумма товаров
        /// </summary>
        public decimal TotalValue { get; set; }

        public Statistics()
        {
        }

        public Statistics(int totalProducts, decimal averagePrice, decimal totalValue)
        {
            TotalProducts = totalProducts;
            AveragePrice = averagePrice;
            TotalValue = totalValue;
        }
    }
}

