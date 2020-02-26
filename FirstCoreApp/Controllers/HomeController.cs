using FirstCoreApp.DB;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace FirstCoreApp.Controllers
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
            CheckboxModel c1 = new CheckboxModel("Day1", false);
            CheckboxModel c2 = new CheckboxModel("Day2", false);
            CheckboxModel c3 = new CheckboxModel("Day3", false);
            List<CheckboxModel> list = new List<CheckboxModel>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            user.boxes = list;
            user.RegDate = DateTime.Today.Date;
            return View(user);

        }

        [HttpPost]
        public ActionResult SubmitNewUser(Users user)
        {
            UserData.CreateNewUser(user.Name,user.Email,user.Gender,user.RegDate, user.boxes,user.AddReq);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult IsNewUser(string name)
        {
            List<Users> list = UserData.GetAllUsers();

            if (list.Where(x => x.Name.Equals(name)).Any()) return Json(false);
            return Json(true);
        }

        public ActionResult IsNewEmail(string email)
        {
            List<Users> list = UserData.GetAllUsers();

            if (list.Where(x => x.Email.Equals(email)).Any()) return Json(false);
            return Json(true);
        }


    }
}