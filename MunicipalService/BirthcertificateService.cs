using FinalEntity;
using FinalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public class BirthcertificateService : Service<BirthCertificate>, IBirthCertificateService
    {
        DataContext context = new DataContext();

        public BirthCertificate GetBByUserID(int uid)
        {
            return this.context.BirthCertificates.SingleOrDefault(u => u.UserId == uid);
        }

        public BirthCertificate GetByID(int id)
        {
            return this.context.BirthCertificates.SingleOrDefault(u => u.UserId == id);
        }

        //public BirthCertificate GetbyId(int id)
        //{
        //    return this.context.BirthCertificates.SingleOrDefault(u => u.Id == id);
        //}
    }
}
