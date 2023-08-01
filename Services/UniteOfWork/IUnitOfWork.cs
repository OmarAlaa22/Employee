using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UniteOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IEmployeeRepository Employee
        {
            get;
        }
        IGovernorateRepository Governate
        {
            get;
        }
        int Save();
    }
}
