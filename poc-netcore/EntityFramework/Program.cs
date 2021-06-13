using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.MyAW;
using EntityFramework.MyModel;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Extensions.Logging;

namespace EntityFramework
{
    class Program
    {
        // Scaffold-DbContext "user id=niels;pwd=S08J1298UHJSD1;server=192.168.63.69;port=5432;database=visi4_test_test46a.bakkerspees.nl;timeout=0" Npgsql.EntityFrameworkCore.PostgreSQL
        static async Task Main(string[] args)
        {
            var template = "{Timestamp:HH:mm:ss} [{Level:u3}] {Message}{Exception} {NewLine}";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(outputTemplate: template) 
                .WriteTo.Debug(outputTemplate: template) 
                .CreateLogger();

            LoggerFactory.Instance = new SerilogLoggerFactory(Log.Logger);

            await using (var ctx = new MyModelContext())
            {
                var list = await ctx.Posts.ToListAsync();
                foreach (var post in list)
                {
                    Log.Information(post.IsCoolBlog().ToString());  
                }
            }

            await using(var ctx = new MyModelContext())
            {
                await ctx.Database.EnsureCreatedAsync();

                // var persoon = new Persoon("Niels", 34, "bla");
                // await ctx.AddAsync(persoon);
                // await ctx.SaveChangesAsync();

                var persoon = await ctx.Personen.SingleAsync(p => p.Id == 2);

                var blog = new Blog("Cool", persoon);
                await ctx.AddAsync(blog);
                await ctx.SaveChangesAsync();

                var post = new Post("Blabla", blog);
                await ctx.AddAsync(post);
                await ctx.SaveChangesAsync();
                
                Log.Information(post.IsCoolBlog().ToString());
            }   
            
            //await awStuff();

            Console.ReadKey();
        }

        private static async Task awStuff()
        {
            await using (var ctx = new MyAWContext())
            {
                var product = await ctx.Products.SingleAsync(p => p.Id == 707);
                Log.Information(product.SubCategory == null ? "mislukt" : "Gelukt");
            }

            await using (var ctx = new MyAWContext())
            {
                var newProduct = new Product {Name = "KlaasHarry"};
                ctx.Add(newProduct);
                await ctx.SaveChangesAsync();
            }
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
