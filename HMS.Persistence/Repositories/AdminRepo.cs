using HMS.Domain.IRepositories;
using HMS.Domain.Model;
using HMS.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence.Repositories
{
    public class AdminRepo : BaseRepo<Admin>, IAdminRepo
    {
        public AdminRepo(HMSContext context) : base(context)
        {

        }
    }
}
