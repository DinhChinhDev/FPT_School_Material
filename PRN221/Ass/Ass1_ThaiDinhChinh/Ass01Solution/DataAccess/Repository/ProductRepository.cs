using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                Product? deleteedProduct = context.Products.FirstOrDefault(p => p.ProductId == id) ?? throw new Exception("No product was found!");
                context.Products.Remove(deleteedProduct);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.Products.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Product GetbyId(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.Products.FirstOrDefault(p => p.ProductId == id);
              
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertProduct(Product p)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.Products.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product p)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified ;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
