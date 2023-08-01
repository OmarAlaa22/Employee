using Domain.Context;
using Domain.Entity;
using Services.Generic;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class CenterRepository : Repository<Center>, ICenterRepository
    {
        public CenterRepository(EmployeeDbContext context) : base(context) { }

    }
}
