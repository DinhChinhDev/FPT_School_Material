using Lab4.Calculate;
using Lab4.Events;
using Lab4.LINQ;

namespace Lab4
{
    internal class Program
    {
        public delegate void SampleDelegate(int a, int b);

        static void HandleBalanceChanged(decimal newBalance)
        {
            Console.WriteLine($"Balance had changed. New balance is: {newBalance:C}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("****Delegate Sample****");
            MathOperations m = new MathOperations();
            SampleDelegate dlgt = m.Add;
            dlgt += m.Subtract;
            dlgt += m.Multiply;
            dlgt(17, 83);
            Console.ReadLine();

            Account userAccount = new Account();
            userAccount.BalanceChanged += HandleBalanceChanged; 
            userAccount.Balance = 1000.00m;

            var brands = new List<Brand>()
            {
                new Brand{Id = 1, name = "Cong ty AAA" },
                new Brand{Id = 2, name = "Cong ty BBB" },
                new Brand{Id = 3, name = "Cong ty CCC" }
            };

            var products = new List<Product>()
            {
                new Product(1, "Ban tra", 400, new string[]{"Xam", "Xanh"}, 2),
                new Product(2, "Tranh treo", 400, new string[]{"Vang", "Xanh"}, 1),
                new Product(3, "Den trum", 400, new string[]{"Vang", "Xanh"}, 1),
                new Product(4, "Ban hoc", 400, new string[]{"Vang", "Xanh"}, 1)
            };

            var ketqua = from product in products
                         join brand in brands on product.Brand equals brand.Id
                         select new
                         {
                             name = product.Name,
                             brand = product.Brand,
                             price = product.Price
                         };
            foreach (var item in ketqua)
            {
                Console.WriteLine($"Name: {item.name,10}, Brand: {item.brand}, Price: {item.price,4}");
            }
        }
    }
}
