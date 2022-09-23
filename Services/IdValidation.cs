using ProductsWithRouting.Models;
using System.Collections.Generic;

namespace ProductsWithRouting.Services
{
    public class IdValidation
    {
        public static bool isValidID(int id, List<Product> data)
        {
            Product prod = data.Find(prod => prod.Id == id);
            if (prod != null) return true;
            else return false;
        }
    }
}
