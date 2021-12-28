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
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ServiceProvider serviceProvider;

        public DoctorService()
        {
            serviceProvider = ServicesRegister.RegisterServices();

            unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public ICollection<Doctor> Find(string search)
        {
            return unitOfWork.DoctorRepository.Get(p => p.Name.Contains(search) || p.Surname.Contains(search) || p.Phone.Contains(search) || p.DoctorSpecialty.Contains(search)).ToList();
        }

        public ICollection<Doctor> GetAll()
        {
            return unitOfWork.DoctorRepository.Get().ToList();
        }

        public Doctor GetById(int id)
        {
            return unitOfWork.DoctorRepository.Get(d => d.Id == id, null, "Schedule").FirstOrDefault();
        }
    }
}
