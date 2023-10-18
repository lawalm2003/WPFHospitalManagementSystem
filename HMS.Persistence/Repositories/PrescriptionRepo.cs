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
    public class PrescriptionRepo : BaseRepo<Prescription>, IPrescriptionRepo
    {
        public PrescriptionRepo(HMSContext context) : base(context)
        {

        }
    }
}
