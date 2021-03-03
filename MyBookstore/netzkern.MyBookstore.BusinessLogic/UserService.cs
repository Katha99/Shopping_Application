using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netzkern.MyBookstore.Data.EF;
using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.BusinessLogic
{
    public class UserService
    {
        public void CreateUser(User user)
        {
            using (EfContext efcontext = new EfContext())
            {
                efcontext.Users.Add(user);
                efcontext.SaveChanges();
            }
        }

        public User LoadUser(string emailAddress)
        {
            User loadedUser = new User();

            using (EfContext efcontext = new EfContext())
            {
                loadedUser = (User)efcontext.Users.Where(x => x.EmailAddress == emailAddress).Select(x => x);
            }

            return loadedUser;
        }
    }
}

