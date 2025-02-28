using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product)
        {
            ProductManagement.Instance.Remove(product);
        }

        public Product GetProductByID(int id)
        {
            return ProductManagement.Instance.GetProductByID(id);
        }


        public IEnumerable<Product> GetProducts()
        {
            return ProductManagement.Instance.GetProductList();
        }

        public void InsertProduct(Product product)
        {
            ProductManagement.Instance.AddNew(product);
        }


        public void UpdateProduct(Product product)
        {
            ProductManagement.Instance.Update(product);
        }
    }
}
