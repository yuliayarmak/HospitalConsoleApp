using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    // класс Пациент
    public class Patient
    {
        // уникальный номер
        [Key]
        public int Id { get; set; }

        // номер карточки
        public int? CardId { get; set; }
        // ссылка на объект карточки
        public virtual Card Card { get; set; }

        public override string ToString()
        {
            return $"{Card.Name, -10} {Card.Surname, -15} {Card.Phone, -12} {Card.BirthDate.ToShortDateString(), -8}";
        }
    }
}
