using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IRegistryService
    {
        /// <summary>
        /// method to get all records
        /// </summary>
        /// <returns>list of records</returns>
        ICollection<Record> GetAllRecords();
        /// <summary>
        /// method to register patient
        /// </summary>
        /// <param name="card">card of a patient to register</param>
        /// <returns>registered patient</returns>
        Patient RegisterPatient(Card card);
        /// <summary>
        /// method to get doctor records by date
        /// </summary>
        /// <param name="doctorId">doctor id to take records</param>
        /// <param name="date">date to select records by</param>
        /// <returns>list of found records</returns>
        ICollection<Record> GetDoctorRecordsByDate(int doctorId, DateTime date);
        /// <summary>
        /// method to add record
        /// </summary>
        /// <param name="r">record to add</param>
        /// <returns>added record with id parameter</returns>
        Record AddRecord(Record r);
    }
}
