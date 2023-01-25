using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductManager
{
   public interface IProduct
    {
        void AddProducts(Product pro);
        void DeleteProduct(int id);
        void UpdateProduct(Product pro);
        List<Product> GetProducts();
    }
    public class ProductRepo : IProduct
    {
        public void AddProducts(Product pro)
        {
            var context = new ProductEntities();
            context.Products.Add(pro);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var context = new ProductEntities();
            var found = context.Products.FirstOrDefault(d => d.ProductId == id);
            if (found == null) throw new Exception("Product Not found");
            context.Products.Remove(found);
            context.SaveChanges();
        }

        public List<Product> GetProducts()
        {
            var context = new ProductEntities();
            var data = context.Products.ToList();
            return data;
        }

        public void UpdateProduct(Product pro)
        {
            var context = new ProductEntities();
            var found = context.Products.FirstOrDefault(d => d.ProductId == pro.ProductId);
            if (found == null) throw new Exception("Product Not found");
            found.ProductPrice = pro.ProductPrice;
            found.Quantity = pro.Quantity;
            context.SaveChanges();
        }
    }
}
