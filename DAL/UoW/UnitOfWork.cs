using DAL.EF;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private HospitalModel context = new HospitalModel();
        private bool disposed = false;

        private IGenericRepository<Card> cardRepository;
        private IGenericRepository<Doctor> doctorRepository;
        private IGenericRepository<Patient> patientRepository;
        private IGenericRepository<Record> recordRepository;
        private IGenericRepository<Registry> registryRepository;
        private IGenericRepository<Schedule> scheduleRepository;

        public IGenericRepository<Card> CardRepository
        {
            get
            {
                if (this.cardRepository == null)
                {
                    this.cardRepository = new GenericRepository<Card>(context);
                }
                return cardRepository;
            }
        }

        public IGenericRepository<Doctor> DoctorRepository
        {
            get
            {
                if (this.doctorRepository == null)
                {
                    this.doctorRepository = new GenericRepository<Doctor>(context);
                }
                return doctorRepository;
            }
        }

        public IGenericRepository<Patient> PatientRepository
        {
            get
            {
                if (this.patientRepository == null)
                {
                    this.patientRepository = new GenericRepository<Patient>(context);
                }
                return patientRepository;
            }
        }

        public IGenericRepository<Record> RecordRepository
        {
            get
            {
                if (this.recordRepository == null)
                {
                    this.recordRepository = new GenericRepository<Record>(context);
                }
                return recordRepository;
            }
        }

        public IGenericRepository<Registry> RegistryRepository
        {
            get
            {
                if (this.registryRepository == null)
                {
                    this.registryRepository = new GenericRepository<Registry>(context);
                }
                return registryRepository;
            }
        }

        public IGenericRepository<Schedule> ScheduleRepository
        {
            get
            {
                if (this.scheduleRepository == null)
                {
                    this.scheduleRepository = new GenericRepository<Schedule>(context);
                }
                return scheduleRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
