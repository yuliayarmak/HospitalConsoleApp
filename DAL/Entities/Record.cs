using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    // класс Запись
    public class Record
    {
        // уникальный номер
        [Key]
        public int Id { get; set; }
        // длительность
        public TimeSpan Duration { get; set; }
        // дата и время записи
        public DateTime Date { get; set; }
        // диагноз
        public string Diagnose { get; set; }

        // номер расписания
        public int ScheduleId { get; set; }
        // ссылка на объект расписания
        public virtual Schedule Schedule { get; set; }

        // номер пациента
        public int PatientId { get; set; }
        // ссылка на объект пациента
        public virtual Patient Patient { get; set; }
    }
}
