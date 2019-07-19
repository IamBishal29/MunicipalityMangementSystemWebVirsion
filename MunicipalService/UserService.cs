using FinalEntity;
using FinalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public class UserService : Service<User>, IUserService
    {
        DataContext context = new DataContext();
      
        public User GetByEmailPass(string email,string password)
        {
            return this.context.Users.SingleOrDefault(u => u.Email == email && u.Password==password );
        }
        public User GetByAdminCheck(bool admincheck)
        {
            return this.context.Users.SingleOrDefault(u =>  u.AdminCheck == admincheck);
        }
        public User GetByEmail(string emailId)
        {
            return this.context.Users.SingleOrDefault(u => u.Email == emailId);
        }

        public User GetByName(string name)
        {
            return this.context.Users.SingleOrDefault(u => u.UserName == name);
        }
    }
}
