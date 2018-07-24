using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using My_Shop.Core.Models;

namespace My_Shop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();
        MyShopEntities bgt = new MyShopEntities();

        public ProductRepository()
        {
            products = cache["product"] as List<Product>;
        if (products == null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("product not found");
            }
        }
        public Product Find(int Id)
        {
            Product product = products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("product not found");
            }
        }
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }
        public void Delet(int Id)
        {
            Product productToDelet = products.Find(p => p.Id == Id);

            if (productToDelet != null)
            {
                products.Remove(productToDelet);
            }
            else
            {
                throw new Exception("product not found");
            }
        }
    }

}
