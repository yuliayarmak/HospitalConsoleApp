using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Card> CardRepository { get; }
        IGenericRepository<Doctor> DoctorRepository { get; }
        IGenericRepository<Patient> PatientRepository { get; }
        IGenericRepository<Record> RecordRepository { get; }
        IGenericRepository<Registry> RegistryRepository { get; }
        IGenericRepository<Schedule> ScheduleRepository { get; }

        void Save();
    }
}
