namespace ProductInventorySystem.Models
{
    /// <summary>
    /// Сущность "Категория"
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор категории (PK)
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }

        public Category()
        {
            CategoryName = string.Empty;
        }

        public Category(int id, string name)
        {
            CategoryID = id;
            CategoryName = name;
        }
    }
}

