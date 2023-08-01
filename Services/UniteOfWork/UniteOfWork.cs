using Domain.Context;
using Domain.Entity;
using Services.Interfaces;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UniteOfWork
{
    public class UniteOfWork:IUnitOfWork
    {
        private readonly EmployeeDbContext context;
        public UniteOfWork(EmployeeDbContext context)
        {
            this.context = context;
            Employee = new EmployeeRepository(this.context);
            Governate = new GovernorateRepository(this.context);
         
        }
        public IEmployeeRepository Employee
        {
            get;
            private set;
        }
        public IGovernorateRepository Governate
        {
            get;
            private set;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
