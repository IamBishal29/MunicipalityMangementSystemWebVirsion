using FinalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public interface IUserService : IService<User>
    {
        User GetByEmailPass(string email,string password);
        User GetByAdminCheck(bool admincheck);
        User GetByEmail(string email);

    }
}
