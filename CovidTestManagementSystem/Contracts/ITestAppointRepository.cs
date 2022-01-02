using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Contracts
{
    public interface ITestAppointRepository : IRepositoryBase<TestAppointment>
    {
        public IEnumerable<TestAppointment> FindAllByUser(string id);
    }
}
