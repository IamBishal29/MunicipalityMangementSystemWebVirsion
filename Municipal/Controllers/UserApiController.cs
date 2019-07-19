using FinalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final.Controllers
{
    public class UserApiController : ApiController
    {
        public IEnumerable<User> Get()
        {
            using (FinalDbEntities ent = new FinalDbEntities())
            {
                return ent.Users.ToList();
            }
        }
    }
}
