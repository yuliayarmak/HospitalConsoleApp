using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    // класс Врач
    public class Doctor
    {
        // уникальный номер
        [Key]
        public int Id { get; set; }

        // имя
        public string Name { get; set; }
        // фамилия
        public string Surname { get; set; }
        // специальность доктора
        public string DoctorSpecialty { get; set; }
        // телефон
        public string Phone { get; set; }

        // номер расписания
        public int? ScheduleId { get; set; }
        // ссылка на объект расписания
        public virtual Schedule Schedule { get; set; }

        // время приема
        [NotMapped]
        public TimeSpan AppointmentTime => new TimeSpan(0, 30, 0);

        // список регистров, в которых работает этот врач
        public virtual ICollection<Registry> Registries { get; set; }

        // конструктор
        public Doctor()
        {
            Registries = new HashSet<Registry>();
        }

        public override string ToString()
        {
            return $"{Name, -10} {Surname, -15} {Phone, -12} {DoctorSpecialty, -8}";
        }
    }
}
