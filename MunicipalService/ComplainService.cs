using FinalEntity;
using FinalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public class ComplainService : Service<Complain>, IComplainService
    {
        DataContext context = new DataContext();
        public Complain GetComplainByUserId(int uid)
        {
            return this.context.Complains.SingleOrDefault(u => u.UserId == uid);
        }

        public Complain GetComplainById(int id)
        {
            return this.context.Complains.SingleOrDefault(u => u.Id == id);
        }
    }

}
