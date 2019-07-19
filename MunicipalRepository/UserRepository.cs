using FinalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        DataContext context = new DataContext();
        public User GetEmail(string email)
        {
           return this.context.Users.SingleOrDefault(u => u.Email == email);  
        }
    }
}
