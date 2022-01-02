using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Person entity)
        {
            _db.Persons.Add(entity);
            return Save();
        }

        public bool Delete(Person entity)
        {
            _db.Persons.Remove(entity);
            return Save();
        }

        public ICollection<Person> FindAll()
        {
            var person = _db.Persons.ToList();
            return person;
        }

        public Person FindById(int id)
        {
            return _db.Persons.Find(id);   
        }

        public Person FindByIdString(string id)
        {
            return _db.Persons.Find(id);
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Person entity)
        {
            _db.Persons.Update(entity);
            return Save();
        }
    }
}
