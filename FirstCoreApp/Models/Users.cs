using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FirstCoreApp.Models;
using FirstCoreApp.Validator;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Models
{
    
    public class Users
    {
        
        public int ID { get; set; }

        [Remote("IsNewUser","Home",HttpMethod ="POST",ErrorMessage ="User name already registered.")]
        [Required(ErrorMessage = "User Name is required")]
        [MaxLength(30)]
        public string Name { get; set; }


        [Remote("IsNewEmail","Home",HttpMethod ="POST",ErrorMessage ="Email already registered.")]
        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Registered date is required")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime),"02/25/2020","02/27/2020", ErrorMessage ="{0} must between 02/25/2020 and 02/27/2020")]
        public DateTime RegDate { get; set; }

        

        public List<CheckboxModel> boxes { get; set; }

        public ICollection<CheckboxModel> selectedDays { get; set; }

        [MaxLength(100)]
        public string AddReq { get; set; }

        public Users()
        {

        }

        public Users(string Name, string Email, string Gender, DateTime datetime, string addreq)
        {
            this.Name = Name;
            this.Email = Email;
            this.Gender = Gender;
            this.RegDate = datetime;
            
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