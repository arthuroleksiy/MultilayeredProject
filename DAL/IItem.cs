using DAL;

namespace DAL
{
    /// <summary>
    /// Sefine <see cref="Category"/> enum.
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// Bakery value
        /// </summary>
        Bakery,
        /// <summary>
        /// Fruits_and_Vegetables value
        /// </summary>
        Fruits_and_Vegetables,
        /// <summary>
        /// Milk_products value
        /// </summary>
        Milk_products,
        /// <summary>
        /// Meat_and_fish value
        /// </summary>
        Meat_and_fish,
        /// <summary>
        /// Canned_food value
        /// </summary>
        Canned_food,
        /// <summary>
        /// Packet_sereals value
        /// </summary>
        Packet_cereals,
        /// <summary>
        /// Drinks value
        /// </summary>
        Drinks,
        /// <summary>
        /// Sweets value
        /// </summary>
        Sweets,
        /// <summary>
        /// Household_Goods value
        /// </summary>
        Household_Goods

    }
    /// <summary>
    /// Define <see cref="IItem"/> interface.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Id value
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name value
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description value
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Total price
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// <see cref="Category"/>
        /// </summary>
        public Category Category { get; set; }
    }
}
