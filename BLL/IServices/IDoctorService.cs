using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IDoctorService
    {
        /// <summary>
        /// method to get all doctors
        /// </summary>
        /// <returns>list of doctors</returns>
        ICollection<Doctor> GetAll();
        /// <summary>
        /// method to get doctor by id
        /// </summary>
        /// <param name="id">id to search a doctor</param>
        /// <returns>Doctor with specified id, if doctor exists, otherwise - null</returns>
        Doctor GetById(int id);
        /// <summary>
        /// method to find doctor by [name | surname | phone | specialty]
        /// </summary>
        /// <param name="search">search query parameter</param>
        /// <returns>list of doctors</returns>
        ICollection<Doctor> Find(string search);
    }
}
