using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Repository
{
    public class NurseRepository : INursesRepository
    {
        private readonly ApplicationDbContext _db;
        public NurseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Nurse entity)
        {
            _db.Nurses.Add(entity);
            return Save();
        }

        public bool Delete(Nurse entity)
        {
            _db.Nurses.Remove(entity);
            return Save();
        }

        public ICollection<Nurse> FindAll()
        {
            var nurses = _db.Nurses.ToList();
            return nurses;
        }

        public Nurse FindById(int id)
        {
            var nurse = _db.Nurses.Find(id);
            return nurse;
        }

        public bool IsExists(int id)
        {
            var exist = _db.Nurses.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Nurse entity)
        {
            _db.Nurses.Update(entity);
           return Save();
            
        }
    }
}
