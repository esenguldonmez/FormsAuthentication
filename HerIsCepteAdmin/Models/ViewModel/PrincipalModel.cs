using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerIsCepteAdmin.Models.ViewModel
{
    public class PrincipalModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PersonalType { get; set; }
        public Nullable<int> Department { get; set; }
        public string[] Roles { get; set; }
    }
}