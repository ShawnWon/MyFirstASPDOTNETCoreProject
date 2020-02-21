using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EONtestEF.Models
{
    
    public class Users
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [MaxLength(30)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Registered date is required")]
        public string regDate { get; set; }

        public bool Days1 { get; set; }
        public bool Days2 { get; set; }
        public bool Days3 { get; set; }


        [MaxLength(100)]
        public string AddReq { get; set; }

        public Users()
        {

        }

        public Users(string Name, string Email, string Gender, string datetime, bool days1, bool days2, bool days3, string addreq)
        {
            this.Name = Name;
            this.Email = Email;
            this.Gender = Gender;
            this.regDate = datetime;
            this.Days1 = days1;
            this.Days2 = days2;
            this.Days3 = days3;
            this.AddReq = addreq;

        }

        public override bool Equals(object obj)
        {
            return obj is Users users &&
                   ID == users.ID;
        }

        public override int GetHashCode()
        {
            return 2108858624 + ID.GetHashCode();
        }
    }
}