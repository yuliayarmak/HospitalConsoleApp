using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    // класс Расписание
    public class Schedule
    {
        // уникальный номер
        [Key]
        public int Id { get; set; }

        // номер врача
        public int DoctorId { get; set; }
        // ссылка на объект врача
        public virtual Doctor Doctor { get; set; }

        // список записей
        public virtual ICollection<Record> Records { get; set; }

        // конструктор
        public Schedule()
        {
            Records = new HashSet<Record>();
        }
    }
}
