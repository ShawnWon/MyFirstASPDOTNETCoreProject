using FirstCoreApp.DB;
using FirstCoreApp.Models;
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


            Users user1 = new Users("Italo Calvino", "pet@gmail.com", "Male", DateTime.Today, "To provide rooms");
            Users user2 = new Users("Milan Kundera", "pet@gmail.com", "Male", DateTime.Today, "To provide rooms");
            Users user3 = new Users("Garcia Marquez", "pet@gmail.com", "Male", DateTime.Today, "To provide rooms");

            CheckboxModel c1 = new CheckboxModel("Day1",true);
            CheckboxModel c2 = new CheckboxModel("Day2", false);
            CheckboxModel c3 = new CheckboxModel("Day3", true);
            List<CheckboxModel> list = new List<CheckboxModel>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);

            foreach (CheckboxModel cm in list)
                context.boxes.Add(cm);


            user1.selectedDays = list;
            context.users.Add(user1);
            context.SaveChanges();

            user2.selectedDays = new List<CheckboxModel>() { new CheckboxModel("Day1", false), new CheckboxModel("Day2", true), new CheckboxModel("Day3", false)};
            context.users.Add(user2);
            context.SaveChanges();

            user3.selectedDays = new List<CheckboxModel>() { new CheckboxModel("Day1", true), new CheckboxModel("Day2", false), new CheckboxModel("Day3", false) };
            context.users.Add(user3);

            context.SaveChanges();

        }
    }
}
