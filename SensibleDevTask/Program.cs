using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SensibleDevTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var personService = new PersonService();
            
            var file1 = args[0];
            var records1 = personService.ReadCsvFile(file1);
            
            var file2 = args[1];
            var records2 = personService.ReadCsvFile(file2);
            
            if (!File.Exists(file1) || !File.Exists(file2))
            {
                Console.WriteLine("Один или оба файла не существуют");
                return;
            }
            
            // Сравнение двух списков
            var addedRecords = records2.Except(records1, new PersonEntityComparer()).ToList();
            var deletedRecords = records1.Except(records2, new PersonEntityComparer()).ToList();
            var modifiedRecords = records2.Intersect(records1, new PersonEntityComparer())
                .Where(r => !r.Equals(records1.Single(p => p.Id == r.Id))).ToList();

            // Отображение различий
            Console.WriteLine("Добавленные записи:");
            foreach (var record in addedRecords)
            {
                Console.WriteLine($"Id: {record.Id}, Имя: {record.Name}, Фамилия: {record.LastName}, " +
                              $"Отчество: {record.Surname}, Дата рождения: {record.DateBirth:dd.MM.yyyy}, Номер телефона: {record.PhoneNumber}");
            }

            Console.WriteLine("Удаленные записи:");
            foreach (var record in deletedRecords)
            {
                Console.WriteLine($"Id: {record.Id}, Имя: {record.Name}, Фамилия: {record.LastName}, " +
                              $"Отчество: {record.Surname}, Дата рождения: {record.DateBirth:dd.MM.yyyy}, Номер телефона: {record.PhoneNumber}");
            }

            Console.WriteLine("Измененные записи:");
            foreach (var record in modifiedRecords)
            {
                var originalRecord = records1.Single(p => p.Id == record.Id);
                var modifiedFields = GetModifiedFields(originalRecord, record);
                Console.WriteLine($"Id: {record.Id}, Измененные поля: {string.Join(", ", modifiedFields)}");
            }
        }

        static IEnumerable<string> GetModifiedFields(PersonEntity originalRecord, PersonEntity modifiedRecord)
        {
            var modifiedFields = new List<string>();

            if (originalRecord.Name != modifiedRecord.Name)
            {
                modifiedFields.Add("Имя");
            }

            if (originalRecord.LastName != modifiedRecord.LastName)
            {
                modifiedFields.Add("Фамилия");
            }

            if (originalRecord.Surname != modifiedRecord.Surname)
            {
                modifiedFields.Add("Отчество");
            }

            if (originalRecord.DateBirth != modifiedRecord.DateBirth)
            {
                modifiedFields.Add("Дата рождения");
            }

            if (originalRecord.PhoneNumber != modifiedRecord.PhoneNumber)
            {
                modifiedFields.Add("Номер телефона");
            }
            
            return modifiedFields;
        }
    }
}
