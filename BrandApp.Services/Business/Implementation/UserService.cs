using BrandApp.Services.Domain.Model;
using BrandApp.Services.Integration.Implementation.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Business.Implementation
{
    public static class UserService
    {
        public static bool RegisterUser(User user)
        {
            var result = 0; 
            if(FindUserCredentialByUserName(user.UserName) == null)
            {
                using (CustomContext ctx = new CustomContext())
                {
                    ctx.UserTable.Add(user);
                    result = ctx.SaveChanges();
                }
            }
            return result > 0 ? true : false;
        }

        public static User FindUserCredentialByUserName(string userName)
        {
            User u;
            using (CustomContext ctx = new CustomContext())
            {
                u = ctx.UserTable.Where(x => x.UserName == userName).FirstOrDefault();
            }
            return u != null ? u : null;
        }

        public static User AuthenticateWebCredential(User user)
        {
            User u;
            using (CustomContext ctx = new CustomContext())
            {
                u = ctx.UserTable.Where(x => x.UserName == user.UserName).Where(x => x.Password == user.Password).FirstOrDefault();
            }
            return u != null ? u : null;
        }
   
    }
}
