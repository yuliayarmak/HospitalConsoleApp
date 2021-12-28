using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IPatientService
    {
        /// <summary>
        /// method to get all patients
        /// </summary>
        /// <returns>list of patients</returns>
        ICollection<Patient> GetAll();
        /// <summary>
        /// method to find patient by [name | surname | phone]
        /// </summary>
        /// <param name="search">search query parameter</param>
        /// <returns>list of found patients</returns>
        ICollection<Patient> Find(string search);
    }
}
