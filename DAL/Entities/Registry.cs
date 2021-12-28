using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    // класс Регистр
    public class Registry
    {
        // уникальный номер
        [Key]
        public int Id { get; set; }

        // список докторов
        public virtual ICollection<Doctor> Doctors { get; set; }
        // список карточек
        public virtual ICollection<Card> Cards { get; set; }

        // не записывать в бд
        [NotMapped]
        public TimeSpan StartWorkTime => new TimeSpan(8, 0, 0);
        [NotMapped]
        public TimeSpan EndWorkTime => new TimeSpan(20, 0, 0);

        // конструктор
        public Registry()
        {
            Doctors = new HashSet<Doctor>();
            Cards = new HashSet<Card>();
        }
    }
}
