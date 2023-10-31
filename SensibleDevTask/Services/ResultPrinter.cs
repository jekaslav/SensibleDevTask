using System;
using System.Collections.Generic;
using System.Linq;

namespace SensibleDevTask.Services
{
    public class ResultPrinter
    {
        private FileComparison _fileComparison;
        private List<PersonEntity> _records1;

        public ResultPrinter(FileComparison fileComparison, List<PersonEntity> records1)
        {
            _fileComparison = fileComparison;
            _records1 = records1;
        }
        
        public void PrintComparisonResults()
        {
            Console.WriteLine("Added records:");
            foreach (var record in _fileComparison.GetAddedRecords())
            {
                Console.WriteLine($"Id: {record.Id}, Имя: {record.Name}, Фамилия: {record.LastName}, " +
                                  $"Отчество: {record.Surname}, Дата рождения: {record.DateBirth:dd.MM.yyyy}, Номер телефона: {record.PhoneNumber}");
            }

            Console.WriteLine("Deleted records:");
            foreach (var record in _fileComparison.GetDeletedRecords())
            {
                Console.WriteLine($"Id: {record.Id}, Имя: {record.Name}, Фамилия: {record.LastName}, " +
                                  $"Отчество: {record.Surname}, Дата рождения: {record.DateBirth:dd.MM.yyyy}, Номер телефона: {record.PhoneNumber}");
            }

            Console.WriteLine("Modified records:");
            foreach (var record in _fileComparison.GetModifiedRecords())
            {
                var originalRecord = _records1.Single(p => p.Id == record.Id);
                var modifiedFields = GetModifiedFields(originalRecord, record);
                Console.WriteLine($"Id: {record.Id}, Измененные поля: {string.Join(", ", modifiedFields)}");
            }
        }
        
        private List<string> GetModifiedFields(PersonEntity originalRecord, PersonEntity modifiedRecord)
        {
            List<string> modifiedFields = new List<string>();

            if (originalRecord.Name != modifiedRecord.Name)
            {
                modifiedFields.Add("Name");
            }

            if (originalRecord.LastName != modifiedRecord.LastName)
            {
                modifiedFields.Add("LastName");
            }

            if (originalRecord.Surname != modifiedRecord.Surname)
            {
                modifiedFields.Add("Surname");
            }

            if (originalRecord.DateBirth != modifiedRecord.DateBirth)
            {
                modifiedFields.Add("DateBirth");
            }

            if (originalRecord.PhoneNumber != modifiedRecord.PhoneNumber)
            {
                modifiedFields.Add("PhoneNumber");
            }

            return modifiedFields;
        }
    }
}