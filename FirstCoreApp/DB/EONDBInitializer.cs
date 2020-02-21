using EONtestEF.DB;
using EONtestEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.DB
{
    public static  class EONDbInitializer
    {
        public static void Initialize(EONDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.users.Any())
            {
                return;
            }


            Users user1 = new Users("Italo Calvino", "pet@gmail.com", "M", DateTime.Today.ToString("yyyy-MM-dd"), true, false, true, "To provide rooms");
            Users user2 = new Users("Milan Kundera", "pet@gmail.com", "M", DateTime.Today.ToString("yyyy-MM-dd"), true, false, true, "To provide rooms");
            Users user3 = new Users("Garcia Marquez", "pet@gmail.com", "M", DateTime.Today.ToString("yyyy-MM-dd"), true, false, true, "To provide rooms");

                

            context.users.Add(user1);
            context.SaveChanges();
            context.users.Add(user2);
            context.SaveChanges();
            context.users.Add(user3);

            context.SaveChanges();

        }
    }
}
