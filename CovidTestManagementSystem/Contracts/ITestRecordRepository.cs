using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Contracts
{
    public interface ITestRecordRepository: IRepositoryBase<TestRecord>
    {
        TestRecord GetTestRecordById(string id);

        public ICollection<TestRecord> GetTestRecordsByPerson(string patientid);


       
    }
}
