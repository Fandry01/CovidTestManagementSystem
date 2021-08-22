using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Repository
{
    public class TestTypeRepository : ITestTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public TestTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(TestTypes entity)
        {
            _db.TestTypes.Add(entity);
            return Save();
        }

        public bool Delete(TestTypes entity)
        {
            _db.TestTypes.Remove(entity);
            return Save();
        }

        public ICollection<TestTypes> FindAll()
        {
            var testTypes = _db.TestTypes.ToList();
            return testTypes;
        }

        public TestTypes FindById(int id)
        {
            var testTypes = _db.TestTypes.Find(id);
            return testTypes;
        }

        public bool IsExists(int id)
        {
            var exist = _db.TestTypes.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(TestTypes entity)
        {
             _db.TestTypes.Update(entity);
            return Save();
            
        }
    }
}
