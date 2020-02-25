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


            /*string name = form["Name"];
            string email = form["Email"];
            DateTime regDate = Convert.ToDateTime(form["regDate"]);
            string addreq = form["AddReq"];
            string gender = form["Gender"];

            string day1check = form["boxes"]; */


            bool x = user.boxes.FirstOrDefault().IsChecked;


            List<Users> list = UserData.GetAllUsers() ;
            if (list.Where(x => x.Name.Equals(user.Name)).Any()||list.Where(x=>x.Email.Equals(user.Email)).Any()) return RedirectToAction("AddUserForm", "Home");

            UserData.CreateNewUser(user.Name,user.Email,user.Gender,user.RegDate, user.boxes,user.AddReq);

            return RedirectToAction("Index", "Home");
        }
    }
}