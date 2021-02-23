using System;
using System.Linq;
using EntityFramework.models;

namespace EntityFramework
{
    class Program
    {
        // Scaffold-DbContext "user id=niels;pwd=S08J1298UHJSD1;server=192.168.63.69;port=5432;database=visi4_test_test46a.bakkerspees.nl;timeout=0" Npgsql.EntityFrameworkCore.PostgreSQL
        static void Main(string[] args)
        {
            var context = new flywayDev45aContext();
            
            var list = context.Transactions
                .Where(t => myTest(t))
                .ToList();

            foreach (var transaction in list)
            {
                int messagesCount = transaction.Messages.Count;
                Console.WriteLine(messagesCount);
            }

            Console.WriteLine("Hello World!");
        }

        private static bool myTest(Transaction t)
        {
            return t.Id % 2 == 0;
        }
    }
}
