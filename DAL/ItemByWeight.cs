using DAL;

namespace DAL
{
    /// <summary>
    /// Define Item by weight derived from <see cref="IItem"/>
    /// </summary>
    public class ItemByWeight: IItem
    {

        /// <value>get the value of id</value>
        public int Id { get; set; }

        /// <value>get the value of Weight</value>
        public double Weight { get; set; }

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
        /// Initializes a new instance of the <see cref="ItemByWeight"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Weight"></param>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        /// <param name="TotalPrice"></param>
        /// <param name="Category"><see cref="Category"/> value</param>
        public ItemByWeight(int id, double Weight, string Name, string Description, decimal Price, decimal TotalPrice, Category Category)
        {
            this.Id = id;
            this.Weight = Weight;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.TotalPrice = TotalPrice;
            this.Category = Category;
        }
    }
}
