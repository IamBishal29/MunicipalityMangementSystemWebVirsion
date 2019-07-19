using FinalEntity;
using FinalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public class BillService : Service<Bill>, IBillService
    {
        DataContext context = new DataContext();
        public Bill GetBillByUserId(int uid)
        {
            return this.context.Bills.SingleOrDefault(u => u.UserId == uid);
        }
    }
}
