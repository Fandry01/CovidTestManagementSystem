using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Contracts
{
    public interface ITestTypeRepository : IRepositoryBase<TestTypes>
    {
        TestTypes GetTestTypeByPatient(string patientId,int TestTypeId);
    }
}
