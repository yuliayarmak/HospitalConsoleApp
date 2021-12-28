using BLL;
using BLL.IServices;
using DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class ConsoleService
    {
        private readonly ServiceProvider serviceProvider;

        private readonly IRegistryService registryService;
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;

        public ConsoleService()
        {
            serviceProvider = ServicesRegister.RegisterServices();

            registryService = serviceProvider.GetRequiredService<IRegistryService>();
            patientService = serviceProvider.GetRequiredService<IPatientService>();
            doctorService = serviceProvider.GetRequiredService<IDoctorService>();
        }

        public void logPatient()
        {

            var doctor = findDoctor();
            if (doctor == null)
                return;

            var patient = findPatient();
            Console.WriteLine(patient);
            if (patient == null)
                return;

            var date = inputDate("Введіть дату та час прийому: ");

            Console.Write("Введіть діагноз: ");
            string diagnose = Console.ReadLine();

            var records = registryService.GetDoctorRecordsByDate(doctor.Id, date);

            var existingRecord = records.FirstOrDefault(r => date >= r.Date && r.Date <= r.Date.Add(r.Duration));
            if (existingRecord != null)
            {
                Console.WriteLine("На жаль, в цей час з " + existingRecord.Date + " до " + existingRecord.Date.Add(existingRecord.Duration) + " зайнято.");
                return;
            }

            var rec = new Record()
            {
                Date = date,
                ScheduleId = (int)doctor.ScheduleId,
                Diagnose = diagnose,
                PatientId = patient.Id,
                Duration = new TimeSpan(0, 30, 0)
            };
            registryService.AddRecord(rec);
            Console.WriteLine($"Клієнт був успішно записаний до {doctor.Name} на {date}");
        }

        public Patient registerPatient()
        {
            Card c = new Card();
            c.Name = inputValue("Введіть ім'я: ");
            c.Surname = inputValue("Введіть прізвище: ");
            c.Phone = inputValue("Введіть номер телефону: ");
            c.BirthDate = inputDate("Введіть дату народження: ");


            return registryService.RegisterPatient(c);
        }

        public DateTime inputDate(string message)
        {
            string dateStr;
            do
            {
                Console.Write(message);
                dateStr = Console.ReadLine();
                if (!DateTime.TryParse(dateStr, out DateTime res))
                {
                    Console.WriteLine("Дата введена некоректно.");
                }
                else
                {
                    return res;
                }
            } while (true);
        }

        public void invokeDatabase()
        {
            // делаем любой запрос к базе данных, чтобы она создалась при старте приложения
            // и не грузилась долго при остальных запросах к ней
            doctorService.GetById(0);
        }

        public Doctor findDoctor()
        {
            var doctors = findDoctors();
            if (!doctors.Any())
                return null;
            string numberStr;
            do
            {
                Console.Write("Введіть номер лікаря, щоб записатись: ");
                numberStr = Console.ReadLine();
                if (!int.TryParse(numberStr, out int index))
                {
                    Console.WriteLine("Некоректний формат номера.");
                }
                else
                {
                    --index;
                    if (index < 0 || index >= doctors.Count)
                    {
                        Console.WriteLine("Некоректний діапазон номера.");
                    }
                    else
                    {
                        return doctors.ElementAt(index);
                    }
                }
            } while (true);
        }

        public Patient findPatient()
        {
            var patients = findPatients();
            if (!patients.Any())
                return null;
            string numberStr;
            do
            {
                Console.Write("Введіть номер пацієнта, щоб записатись: ");
                numberStr = Console.ReadLine();
                if (!int.TryParse(numberStr, out int index))
                {
                    Console.WriteLine("Некоректний формат номера.");
                }
                else
                {
                    --index;
                    if (index < 0 || index >= patients.Count)
                    {
                        Console.WriteLine("Некоректний діапазон номера.");
                    }
                    else
                    {
                        return patients.ElementAt(index);
                    }
                }
            } while (true);
        }

        public ICollection<Patient> findPatients()
        {
            Console.Write("\t\t- Пошук пацієнта -\nПошук здійснюється за прізвищем/іменем/телефоном\nВведіть пошуковий запит: ");
            string searchString = Console.ReadLine();

            var found = patientService.Find(searchString);

            if (!found.Any())
            {
                Console.WriteLine($"На жаль, за запитом \"{searchString}\" не було знайдено результатів.");
                return found;
            }
            for (int i = 0; i < found.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + found.ElementAt(i));
            }
            return found;
        }

        public ICollection<Doctor> findDoctors()
        {
            Console.Write("\t\t- Пошук лікаря -\nПошук здійснюється за прізвищем/іменем/телефоном/спеціальністю\nВведіть пошуковий запит: ");
            string searchString = Console.ReadLine();

            var found = doctorService.Find(searchString);

            if (!found.Any())
            {
                Console.WriteLine($"На жаль, за запитом \"{searchString}\" не було знайдено результатів.");
                return found;
            }
            for (int i = 0; i < found.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + found.ElementAt(i));
            }
            return found;
        }

        public string inputValue(string message)
        {
            string value;
            do
            {
                Console.Write(message);
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Значення не може бути пустим!");
                else return value;
            } while (true);
        }
    }
}
