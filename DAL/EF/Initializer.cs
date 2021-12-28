using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Initializer : CreateDatabaseIfNotExists<HospitalModel>
    {
        protected override void Seed(HospitalModel context)
        {

            var d1 = context.Doctors.Add(new Doctor()
            {
                Name = "Марина",
                Surname = "Таращук",
                Phone = "+380678043334",
                DoctorSpecialty = "Анестезіологія"
            });

            var d2 = context.Doctors.Add(new Doctor()
            {
                Name = "Марія",
                Surname = "Гнатюк",
                Phone = "+380670251673",
                DoctorSpecialty = "Генетика"
            });

            var d3 = context.Doctors.Add(new Doctor()
            {
                Name = "Констянтин",
                Surname = "Мельниченко",
                Phone = "+380676292381",
                DoctorSpecialty = "Дерматовенерологія"
            });

            var d4 = context.Doctors.Add(new Doctor()
            {
                Name = "Георгій",
                Surname = "Сергієнко",
                Phone = "+380673782801",
                DoctorSpecialty = "Офтальмологія"
            });

            var d5 = context.Doctors.Add(new Doctor()
            {
                Name = "Євген",
                Surname = "Гнатюк",
                Phone = "+380678493810",
                DoctorSpecialty = "Психіатрія"
            });

            var d6 = context.Doctors.Add(new Doctor()
            {
                Name = "Юлія",
                Surname = "Василенко",
                Phone = "+380676571200",
                DoctorSpecialty = "Стоматологія"
            });

            var d7 = context.Doctors.Add(new Doctor()
            {
                Name = "Тимофій",
                Surname = "Іванченко",
                Phone = "+380676473013",
                DoctorSpecialty = "Хірургія"
            });


            var d8 = context.Doctors.Add(new Doctor()
            {
                Name = "Анатолій",
                Surname = "Василенко",
                Phone = "+380677823913",
                DoctorSpecialty = "Дієтологія"
            });


            var d9 = context.Doctors.Add(new Doctor()
            {
                Name = "Олена",
                Surname = "Захарчук",
                Phone = "+380671630483",
                DoctorSpecialty = "Ендоскопія"
            });


            var d10 = context.Doctors.Add(new Doctor()
            {
                Name = "Михайло",
                Surname = "Броварчук",
                Phone = "+380678473810",
                DoctorSpecialty = "Кардіологія"
            });

            context.SaveChanges();

            var r1 = context.Registries.Add(new Registry());
            context.SaveChanges();
            r1.Doctors.Add(d1);
            r1.Doctors.Add(d2);
            r1.Doctors.Add(d3);
            r1.Doctors.Add(d4);
            r1.Doctors.Add(d5);
            r1.Doctors.Add(d6);
            r1.Doctors.Add(d7);
            r1.Doctors.Add(d8);
            r1.Doctors.Add(d9);
            r1.Doctors.Add(d10);

            context.SaveChanges();

            var s1 = context.Schedules.Add(new Schedule()
            {
                Doctor = d1,
                DoctorId = d1.Id
            });
            var s2 = context.Schedules.Add(new Schedule()
            {
                Doctor = d2,
                DoctorId = d2.Id
            });
            var s3 = context.Schedules.Add(new Schedule()
            {
                Doctor = d3,
                DoctorId = d3.Id
            });
            var s4 = context.Schedules.Add(new Schedule()
            {
                Doctor = d4,
                DoctorId = d4.Id
            });
            var s5 = context.Schedules.Add(new Schedule()
            {
                Doctor = d5,
                DoctorId = d5.Id
            });
            var s6 = context.Schedules.Add(new Schedule()
            {
                Doctor = d6,
                DoctorId = d6.Id
            });
            var s7 = context.Schedules.Add(new Schedule()
            {
                Doctor = d7,
                DoctorId = d7.Id
            });
            var s8 = context.Schedules.Add(new Schedule()
            {
                Doctor = d8,
                DoctorId = d8.Id
            });
            var s9 = context.Schedules.Add(new Schedule()
            {
                Doctor = d9,
                DoctorId = d9.Id
            });
            var s10 = context.Schedules.Add(new Schedule()
            {
                Doctor = d10,
                DoctorId = d10.Id
            });

            context.SaveChanges();

            d1.ScheduleId = s1.Id;
            d2.ScheduleId = s2.Id;
            d3.ScheduleId = s3.Id;
            d4.ScheduleId = s4.Id;
            d5.ScheduleId = s5.Id;
            d6.ScheduleId = s6.Id;
            d7.ScheduleId = s7.Id;
            d8.ScheduleId = s8.Id;
            d9.ScheduleId = s9.Id;
            d10.Schedule.Id = s10.Id;

            context.SaveChanges();

        }
    }
}
