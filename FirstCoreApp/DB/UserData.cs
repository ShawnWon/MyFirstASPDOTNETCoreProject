using EONtestEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EONtestEF.DB
{
    public class UserData
    {




        public static List<Users> GetAllUsers()
        {
            List<Users> list = new List<Users>();

            using (var _context = new EONDbContext())
            {
                if (_context.users.Any())
                    list = _context.users.ToList();
            }


            return list;
        }

        internal static void CreateNewUser(string name, string email, string gender, string regDate, bool days1, bool days2, bool days3, string addreq)
        {
            Users user = new Users();



            user.Name = name;
            user.Email = email;
            user.Gender = gender;
            user.regDate = regDate;
            user.Days1 = days1;
            user.Days2 = days2;
            user.Days3 = days3;

            user.AddReq = addreq;

            using (var _context = new EONDbContext())
            {
                _context.users.Add(user);
                _context.SaveChanges();
            }

        }
    }
}
