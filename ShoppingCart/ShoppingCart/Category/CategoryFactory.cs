using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Category
{
    public class CategoryFactory
    {
        public Category Get(CategoryTypes categoryTypes)
        {
            Category category = null;

            switch (categoryTypes)
            {
                case CategoryTypes.Electronic:
                    category = new ElectronicCategory();
                    break;
                case CategoryTypes.Phone:
                    category = new PhoneCategory();
                    break;
                case CategoryTypes.Computer:
                    category = new ComputerCategory();
                    break;
            }

            return category;
        }
    }
}
