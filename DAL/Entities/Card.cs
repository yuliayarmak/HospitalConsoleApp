using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    // класс Карточка
    public class Card
    {
        // уникальный номер
        [Key]
        public int Id { get; set; }

        // имя
        public string Name { get; set; }
        // фамилия
        public string Surname { get; set; }
        // телефон
        public string Phone { get; set; }
        // дата рождения
        public DateTime BirthDate { get; set; }

        // номер пациента
        public int PatientId { get; set; }
        // ссылка на объект пациента
        public virtual Patient Patient { get; set; }
        // номер регистра
        [ForeignKey(nameof(Registry))]
        public int RegistryId { get; set; }
        // ссылка на объект регистра
        public virtual Registry Registry { get; set; }

        // список записей
        public virtual ICollection<Record> Records { get; set; }
        // конструктор
        public Card()
        {
            Records = new HashSet<Record>();
        }
    }
}
