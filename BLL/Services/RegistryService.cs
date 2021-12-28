using BLL.IServices;
using DAL.Entities;
using DAL.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegistryService : IRegistryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ServiceProvider serviceProvider;

        public RegistryService()
        {
            serviceProvider = ServicesRegister.RegisterServices();

            unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public Record AddRecord(Record r)
        {
            var rec = unitOfWork.RecordRepository.Insert(r);
            unitOfWork.Save();
            return rec;
        }

        public ICollection<Record> GetAllRecords()
        {
            return unitOfWork.RecordRepository.Get().ToList();
        }

        public ICollection<Record> GetDoctorRecordsByDate(int doctorId, DateTime date)
        {
            var records = unitOfWork.RecordRepository.Get(r => r.Schedule.DoctorId == doctorId && r.Date == date);
            return records.ToList();
        }

        public Patient RegisterPatient(Card card)
        {
            var registry = unitOfWork.RegistryRepository.GetByID(1);
            if (registry == null)
            {
                throw new Exception("Регістр не існує");
            }
            var p = unitOfWork.PatientRepository.Insert(new Patient());
            unitOfWork.Save();
            card.Patient = p;
            card.PatientId = p.Id;
            card.Registry = registry;
            var c = unitOfWork.CardRepository.Insert(card);
            unitOfWork.Save();
            p.CardId = c.Id;
            unitOfWork.Save();
            return p;
        }
    }
}
