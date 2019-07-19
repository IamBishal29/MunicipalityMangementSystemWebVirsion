using FinalEntity;
using FinalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public class VoterIdService : Service<VoterId>, IVoterIdService
    {
        DataContext context = new DataContext();

        public VoterId GetByUserID(int uid)
        {
            return this.context.VoterIds.SingleOrDefault(u => u.UserId == uid);
        }
    }
}
