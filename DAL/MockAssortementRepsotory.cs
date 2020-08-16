using System;
using System.Collections.Generic;


namespace DAL
{
    /// <summary>
    /// The MockAssortementRepsotory class.
    /// Contains all data and methods for operating supermarket assortement.
    /// </summary>
    public static class MockAssortementRepsotory
    {
        /// <value>
        /// returns Collection of <see cref="IItem"/> assortment
        /// </value>
        public static IEnumerable<IItem> Assortement { get; set; } = new List<IItem>
        {
            new ItemByNumber(1,1,"White bread", "", 10, 10, Category.Bakery),
            new ItemByNumber(2,1,"Black bread", "", 11.50m,11.50m, Category.Bakery),

            new ItemByWeight(3,1.00,"Tomatoes","",30.0m,30.0m, Category.Fruits_and_Vegetables),
            new ItemByWeight(4,1.00,"Cucumbers","",35.0m,35.0m, Category.Fruits_and_Vegetables),
            new ItemByWeight(5,1.00,"Bananas","",25.0m,25.0m, Category.Fruits_and_Vegetables),
            new ItemByWeight(6,1.00,"Onion","",12.0m,12.0m, Category.Fruits_and_Vegetables),
            new ItemByWeight(7,1.00,"Potato","",10.0m,10.0m, Category.Fruits_and_Vegetables),

            new ItemByNumber(8,1,"Milk", "", 23.0m,23.0m, Category.Milk_products),
            new ItemByNumber(9,1,"Cheese", "", 30m,30m, Category.Milk_products),

            new ItemByWeight(10,1.00,"Chicken","",65.0m,65.0m, Category.Meat_and_fish),
            new ItemByWeight(11,1.00,"Pork","",180.0m,180.0m, Category.Meat_and_fish),
            new ItemByWeight(12,1.00,"Salmon","",150.0m,150.0m, Category.Meat_and_fish),

            new ItemByNumber(13,1,"Canned vegetables", "", 45.0m,45.0m, Category.Canned_food),
            new ItemByNumber(14,1,"Canned olives", "", 60m,60m, Category.Canned_food),

            new ItemByNumber(15,1,"Pasta","",20.0m,20.0m, Category.Packet_cereals),
            new ItemByNumber(16,1,"Rice","",30.0m,30.0m, Category.Packet_cereals),
            new ItemByNumber(17,1,"Sugar","",35.0m,35.0m, Category.Packet_cereals),

            new ItemByNumber(18,1,"Coca-Cola", "", 23.0m,23.0m, Category.Drinks),
            new ItemByNumber(19,1,"Fanta", "", 25m,25m, Category.Drinks),
            new ItemByNumber(20,1,"Mineral water", "", 10m,10m, Category.Drinks),

            new ItemByNumber(21,1,"M&ms", "", 23.0m,23.0m, Category.Sweets),
            new ItemByNumber(22,1,"Pringles", "", 30m,30m, Category.Sweets),

            new ItemByWeight(23,1.0, "Chocolate candys","",45.50m,45.50m, Category.Sweets),
            new ItemByWeight(24,1.00, "Cookies","",65.50m,65.50m, Category.Sweets),

            new ItemByNumber(25,1,"Mr.Muscle", "", 65.0m,65.0m, Category.Household_Goods),
            new ItemByNumber(26,1,"Fairy", "", 45.50m,45.50m, Category.Household_Goods),
            new ItemByNumber(27,1,"Colgate", "", 50.0m,50.0m, Category.Household_Goods),
            new ItemByNumber(28,1,"Tide", "", 80.0m,80.0m, Category.Household_Goods)

        };

        /// <summary>
        /// Gets last id
        /// </summary>
        /// <returns>Last int id</returns>
        public static int GetLastId()
        {
            int greatest = 0;
            foreach(var i in Assortement)
            {
                if(i.Id > greatest)
                {
                    greatest = i.Id;
                }
            }

            return greatest;
        }
        /// <summary>
        /// Gets item of specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="IItem"/> value</returns>
        public static IItem GetItemById(int id)
        {
            foreach (var i in Assortement)
            {
                if (i.Id.Equals(id))
                {
                    return i;
                }
            }

            return null;
        }

    }
}
