using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLesson4Task1 // And task2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Task1
            //using (ShopDBContext db = new ShopDBContext())
            //{
            //    List<Product> products = db.Products.ToList();
            //    foreach (Product p in products)
            //        Console.WriteLine($"{p.ProdId}, {(p.Description).Trim()}, {p.UnitPrice}, {p.Weight}");
            //}

            //Task2

            int prodID;

            Console.WriteLine("Choose ID of your product");
            bool boo = int.TryParse(Console.ReadLine(), out prodID);

            Product prod = await GetProductAtIDAsync(new ShopDBContext(), prodID);
            Console.WriteLine($"{prod.ProdId}, {(prod.Description).Trim()}, {prod.Weight}");

        }

        static async Task<Product> GetProductAtIDAsync(ShopDBContext db, int prodId)
        {
            using (db)
            {
                return await Task<Product>.Run(() =>
                {
                    Product prod = db.Products.FromSqlRaw("exec ShowProductsAtID @p0", new SqlParameter("@p0", prodId))
                .AsEnumerable().FirstOrDefault<Product>();
                    return prod;
                });
            }

        }

    }
}

