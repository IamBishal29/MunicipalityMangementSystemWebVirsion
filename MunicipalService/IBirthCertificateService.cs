using FinalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public interface IBirthCertificateService : IService<BirthCertificate>
    {
        BirthCertificate GetBByUserID(int uid);

        BirthCertificate GetByID(int id);

        //BirthCertificate GetbyId(int id);
    }
}
