using FinalTest1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTest1.Contextos
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {

        public IdentityDb()
            : base("DefaultConnection")
        {
        }
        
        public static  IdentityDb Create()
        {
            return new IdentityDb();
        }
         
    }
}