using HMS.Domain.IRepositories;
using HMS.Domain.Model;
using HMS.Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(HMSContext context) : base(context)
        {

        }
    }
}
