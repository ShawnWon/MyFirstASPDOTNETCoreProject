using FirstCoreApp.DB;
using FirstCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstCoreApp.DB
{
    public class UserData
    {




        public static List<Users> GetAllUsers()
        {
            List<Users> list = new List<Users>();

            using (var _context = new EONDbContext())
            {
                if (_context.users.Any())
                    list = _context.users.Include("boxes").ToList();
            }


            return list;
        }

        internal static void CreateNewUser(string name, string email, string gender, DateTime regDate, List<CheckboxModel> list,string addreq)
        {
            Users user = new Users();



            user.Name = name;
            user.Email = email;
            user.Gender = gender;
            user.RegDate = regDate;
            user.boxes = list;

            user.AddReq = addreq;

            using (var _context = new EONDbContext())
            {
                _context.users.Add(user);
                _context.SaveChanges();
            }

        }
    }
}
