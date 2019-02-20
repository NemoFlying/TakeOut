using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.Models;

namespace TakeOut.ViewModels
{
    public class UserInfo
    {
        public User User { get; set; }

        public List<Role> roles { get; set; }
    }
}