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
using FirstCoreApp.DB;


namespace EONtestEF.Controllers
{
    public class HomeController : Controller
    {

        

        public ActionResult Index()
        {
            

            List<Users> listusers = UserData.GetAllUsers();
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

            List<Users> list = UserData.GetAllUsers() ;
            if (list.Where(x => x.Name.Equals(name)).Any()) return RedirectToAction("AddUserForm", "Home");

            UserData.CreateNewUser(name,email,gender,regDate,day1check,day2check,day3check,addreq);

            return RedirectToAction("Index", "Home");
        }
    }
}