using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    internal class ProductManagement
    {
        private static ProductManagement instance = null;
        public static readonly object instanceLock = new object();

        private ProductManagement() { }
        public static ProductManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductManagement();
                    }
                    return instance;
                }
            }
        }


        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var myContextDB = new PRN221_As01Context();
                products = myContextDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductByID(int id)
        {
            Product Product = null;
            try
            {
                var myContextDB = new PRN221_As01Context();
                Product = myContextDB.Products.SingleOrDefault(item => item.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Product;
        }

        public void AddNew(Product Product)
        {
            try
            {
                Product currentProduct = GetProductByID(Product.ProductId);
                if (currentProduct == null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Products.Add(Product);
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product Product)
        {
            try
            {
                Product currentProduct = GetProductByID(Product.ProductId);
                if (currentProduct != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Entry(Product).State = EntityState.Modified;
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Product Product)
        {
            try
            {
                Product currentProduct = GetProductByID(Product.ProductId);
                if (currentProduct != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Products.Remove(Product);
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
