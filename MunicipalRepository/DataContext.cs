using FinalEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalRepository
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }
        public DbSet<VoterId> VoterIds { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Complain> Complains { get; set; }

    }
}
