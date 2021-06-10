using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.MyAW;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EntityFramework
{
    class Program
    {
        // Scaffold-DbContext "user id=niels;pwd=S08J1298UHJSD1;server=192.168.63.69;port=5432;database=visi4_test_test46a.bakkerspees.nl;timeout=0" Npgsql.EntityFrameworkCore.PostgreSQL
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                // en dit met die :
                .MinimumLevel.Verbose()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message}{Exception} {NewLine}") 
                .CreateLogger();
            
            await using (var ctx = new MyAWContext())
            {
                var product = await ctx.Products.SingleAsync(p => p.Id == 707);
                Log.Information(product.SubCategory == null ? "mislukt" : "Gelukt");

                var newProduct = new Product();
                newProduct.Name = "KlaasHarry";
                if (product.SubCategoryId != null) newProduct.SubCategoryId = product.SubCategoryId.Value;
                ctx.Add(newProduct);
                await ctx.SaveChangesAsync();
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
        //
        // private static void dev45stuff()
        // {
        //     var context = new flywayDev45aContext();
        //
        //     // var list = context.Transactions
        //     //     //.Where(t => myTest(t))
        //     //     .ToList();
        //
        //     var find = context.Transactions.Find(12);
        //
        //     var transactiontypeNameBefore = find.Transactiontype.Name;
        //     find.Transactiontypeid = 17;
        //     var entityEntry = context.Entry(find);
        //     entityEntry.State = EntityState.Modified;
        //     context.SaveChanges();
        //
        //     var transactiontypeName = find.Transactiontype.Name;
        //
        //     // foreach (var transaction in list)
        //     // {
        //     //     var transactiontypeNameBefore = transaction.Transactiontype.Name;
        //     //     transaction.Transactiontypeid = 17;
        //     //     var transactiontypeName = transaction.Transactiontype.Name;
        //     //     int messagesCount = transaction.Messages.Count;
        //     //     Console.WriteLine(messagesCount);
        //     // }
        //
        //     Console.WriteLine("Hello World!");
        // }
        //
        // private static bool myTest(Transaction t)
        // {
        //     return t.Id % 2 == 0;
        // }
    }
}
