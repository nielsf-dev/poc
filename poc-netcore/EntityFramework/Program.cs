using System;
using System.Diagnostics;
using System.Linq;
using EntityFramework.models;
using EntityFramework.MyAW;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    class Program
    {
        // Scaffold-DbContext "user id=niels;pwd=S08J1298UHJSD1;server=192.168.63.69;port=5432;database=visi4_test_test46a.bakkerspees.nl;timeout=0" Npgsql.EntityFrameworkCore.PostgreSQL
        static void Main(string[] args)
        {
            var ctx = new MyAWContext();
            var product = ctx.Products.Find(707);

            if(product.SubCategory == null)
                Console.Out.WriteLine("mislukt");
            else
            {
                Console.Out.WriteLine("Gelukt");
            }

            // Console.WriteLine($"Total products = {products.Count}");
            // foreach (var product in products)
            // {
            //     Console.Out.WriteLine(product.Name);
            //
            //     Console.Out.WriteLine(product.ProductSubCategory != null
            //         ? product.ProductSubCategory.Name
            //         : "Is er niet");
            //
            //     Console.Out.WriteLine(" ");
            // }
            Console.ReadKey();
        }

        private static void dev45stuff()
        {
            var context = new flywayDev45aContext();

            // var list = context.Transactions
            //     //.Where(t => myTest(t))
            //     .ToList();

            var find = context.Transactions.Find(12);

            var transactiontypeNameBefore = find.Transactiontype.Name;
            find.Transactiontypeid = 17;
            var entityEntry = context.Entry(find);
            entityEntry.State = EntityState.Modified;
            context.SaveChanges();

            var transactiontypeName = find.Transactiontype.Name;

            // foreach (var transaction in list)
            // {
            //     var transactiontypeNameBefore = transaction.Transactiontype.Name;
            //     transaction.Transactiontypeid = 17;
            //     var transactiontypeName = transaction.Transactiontype.Name;
            //     int messagesCount = transaction.Messages.Count;
            //     Console.WriteLine(messagesCount);
            // }

            Console.WriteLine("Hello World!");
        }

        private static bool myTest(Transaction t)
        {
            return t.Id % 2 == 0;
        }
    }
}
