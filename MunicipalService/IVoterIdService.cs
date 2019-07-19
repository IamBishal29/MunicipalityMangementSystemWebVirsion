using FinalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    
    public interface IVoterIdService : IService<VoterId>
    {
        VoterId GetByUserID(int uid);
    }
}
