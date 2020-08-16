using DAL;


namespace DAL
{
    /// <summary>
    /// Defines ItemByNumber enum and inherit <see cref="IItem"/> interface.
    /// </summary>
    public class ItemByNumber: IItem
    {
        /// <value>get the value of id</value>
        public int Id { get; set; }

        /// <value>get the value of Number</value>
        public int Number { get; set; }

        /// <value>get the value of Name</value>
        public string Name { get; set; }

        /// <value>get the value of Description</value>
        public string Description { get; set; }

        /// <value>get the value of Price</value>
        public decimal Price { get; set; }

        /// <value>get the value of TotalPrice</value>
        public decimal TotalPrice { get; set; }

        /// <value>get the value of <see cref="Category"/></value>
        public Category Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemByNumber"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Number"></param>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        /// <param name="TotalPrice"></param>
        /// <param name="Category"><see cref="Category"/> value</param>
        public ItemByNumber(int id, int Number, string Name, string Description, decimal Price, decimal TotalPrice, Category Category)
        {
            this.Id = id;
            this.Number = Number;
            this.Name = Name;
            this.TotalPrice = TotalPrice;
            this.Description = Description;
            this.Price = Price;
            this.Category = Category;
        }

    }
}
