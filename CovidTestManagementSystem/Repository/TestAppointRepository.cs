using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Repository
{
    public class TestAppointRepository : ITestAppointRepository
    {
        private readonly ApplicationDbContext _db;
        public TestAppointRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(TestAppointment entity)
        {
            _db.TestAppointments.Add(entity);
            return Save();
        }

        public bool Delete(TestAppointment entity)
        {
            _db.TestAppointments.Remove(entity);
            return Save();
        }

        public ICollection<TestAppointment> FindAll()
        {
            var appointments = _db.TestAppointments.ToList();
            foreach(var app in appointments)
            {
                app.TestType = _db.TestTypes.Find(app.TestTypeId);
                app.TestRecord = _db.TestRecords.Find(app.TestRecordId);
                app.Patient = _db.Persons.Find(app.PatientId);
            }
            return appointments;
        }

        public IEnumerable<TestAppointment> FindAllByUser(string id)
        {
            return FindAll().Where(p => p.PatientId == id);
            
        }

        public TestAppointment FindById(int id)
        {
            var appointment = _db.TestAppointments.Find(id);
            appointment.TestType = _db.TestTypes.Find(appointment.TestTypeId);
            appointment.TestRecord = _db.TestRecords.Find(appointment.TestRecordId);
            appointment.Patient = _db.Persons.Find(appointment.PatientId);
            return appointment;
        }

        public bool IsExists(int id)
        {
            var exist = _db.TestAppointments.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(TestAppointment entity)
        {
            _db.TestAppointments.Update(entity);
            return Save();
        }
    }
}
