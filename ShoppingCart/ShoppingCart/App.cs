using ShoppingCart.Category;
using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Product;

namespace ShoppingCart
{
    /// <summary>
    /// The App.cs class that will be used to run the application and will contain all of the running console application code.
    /// </summary>
    class App
    {
        public void Run()
        {
            CategoryFactory categoryFactory = new CategoryFactory();
            var electronicCategory = categoryFactory.Get(CategoryTypes.Electronic);
            var computerCategory = categoryFactory.Get(CategoryTypes.Computer, electronicCategory);
            var phoneCategory = categoryFactory.Get(CategoryTypes.Phone, electronicCategory);

            var ipone = new Iphone(7500, phoneCategory);
            var macbook = new Macbook(18500, computerCategory);

            Console.WriteLine(ipone.Title + " " + ipone.Price + " " + ipone.Category.ParentCategory.Title + " " + ipone.Category.Title);
            Console.WriteLine(macbook.Title + " " + macbook.Price + " " + macbook.Category.ParentCategory.Title + " " + macbook.Category.Title);
            Console.ReadLine();

        }
    }
}
