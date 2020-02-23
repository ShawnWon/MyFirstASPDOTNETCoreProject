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


            return View();

        }

        public ActionResult SubmitNewUser(IFormCollection form)
        {
            

            string name = form["Name"];
            string email = form["Email"];
            DateTime regDate = Convert.ToDateTime(form["regDate"]);
            string addreq = form["AddReq"];
            string gender = form["Gender"];

            bool day1check = form["Days1"].ToString().Substring(0,4).Equals("true",StringComparison.CurrentCultureIgnoreCase); 
            bool day2check = form["Days2"].ToString().Substring(0, 4).Equals("true", StringComparison.CurrentCultureIgnoreCase);
            bool day3check = form["Days3"].ToString().Substring(0, 4).Equals("true", StringComparison.CurrentCultureIgnoreCase);

            List<Users> list = UserData.GetAllUsers() ;
            if (list.Where(x => x.Name.Equals(name)).Any()) return RedirectToAction("AddUserForm", "Home");

            UserData.CreateNewUser(name,email,gender,regDate,day1check,day2check,day3check,addreq);

            return RedirectToAction("Index", "Home");
        }
    }
}