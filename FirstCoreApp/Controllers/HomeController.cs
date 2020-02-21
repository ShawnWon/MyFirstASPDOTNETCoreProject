using EONtestEF.DB;
using EONtestEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace EONtestEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly EONDbContext _context;

        public HomeController(EONDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            List<Users> listusers = _context.users.ToList();
            ViewBag.listuser = listusers;
            return View();
        }

        public ActionResult AddUserForm()
        {
            Users user = new Users();


            return View();

        }

        public ActionResult SubmitNewUser(IFormCollection form)
        {
            string name = form["Name"];
            string email = form["Email"];
            string regDate = form["regDate"];
            string addreq = form["AddReq"];
            string gender = form["Gender"];

            string days1 = form["Days1"];
            string days2 = form["Days2"];
            string days3 = form["Days3"];

            bool day1check = true; //Need to convert above string into bool value here
            bool day2check = false;
            bool day3check = true;

            List<Users> list = _context.users.ToList();
            if (list.Where(x => x.Name.Equals(name)).Any()) return RedirectToAction("AddUserForm", "Home");


            _context.Add(new Users(name, email, gender, regDate, day1check, day2check, day3check, addreq));
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}