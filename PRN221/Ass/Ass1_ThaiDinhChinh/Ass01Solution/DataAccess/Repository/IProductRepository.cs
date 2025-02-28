using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public Product GetbyId(int id);
        public List<Product> GetAll();
        public void InsertProduct(Product p);
        public void UpdateProduct(Product p);
        public void DeleteProduct(int id);
       


    }
}
