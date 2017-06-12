using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Security.Models
{
    public class RoleDetailViewModel
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public ICollection<ApplicationUser> UserUitRole { get; set; }
        public List<SelectListItem> SelectUser { get; set; }
        public string SelectedUser { get; set; }
    }
}