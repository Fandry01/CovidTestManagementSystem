using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Repository
{
    public class TestRecordRepository : ITestRecordRepository
    {
        private readonly ApplicationDbContext _db;
        public TestRecordRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(TestRecord entity)
        {
          _db.TestRecords.Add(entity);

            return Save();
        }

        public bool Delete(TestRecord entity)
        {
            _db.TestRecords.Remove(entity);
            return Save();
        }

        public ICollection<TestRecord> FindAll()
        {
            var records = _db.TestRecords.ToList();
            foreach (var rec in records)
            {
                rec.Patient = _db.Persons.Find(rec.Patient);
                rec.TestType = _db.TestTypes.Find(rec.TestTypeId);
            }
            return records;
        }

        public TestRecord FindById(int id)
        {
            var record = _db.TestRecords.Find(id);
            return record;
        }

        public TestRecord GetTestRecordById(string id)
        {
            return _db.TestRecords.Find(id);
        }

        public ICollection<TestRecord> GetTestRecordsByPerson(string patientId)
        {
            var getrecord = _db.TestRecords.ToList();
            return getrecord;
        }

        public bool IsExists(int id)
        {
            var exist = _db.TestRecords.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(TestRecord entity)
        {
            _db.TestRecords.Update(entity);
            return Save();
        }
    }
}
