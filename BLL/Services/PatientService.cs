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
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ServiceProvider serviceProvider;

        public PatientService()
        {
            serviceProvider = ServicesRegister.RegisterServices();

            unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public ICollection<Patient> Find(string search)
        {
            return unitOfWork.PatientRepository.Get(p => p.Card.Name.Contains(search) || p.Card.Surname.Contains(search) || p.Card.Phone.Contains(search), null, "Card").ToList();
        }

        public ICollection<Patient> GetAll()
        {
            return unitOfWork.PatientRepository.Get().ToList();
        }
    }
}
