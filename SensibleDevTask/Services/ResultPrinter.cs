using System;
using System.Collections.Generic;
using System.Linq;
using SensibleDevTask.Entities;

namespace SensibleDevTask.Services
{
    public static class ResultPrinter
    {
        public static void PrintComparisonResults(List<PersonEntity> addedRecords, List<PersonEntity> deletedRecords, 
            List<PersonEntity> modifiedRecords, List<PersonEntity> records1)
        {
            Console.WriteLine("Added records:");
            foreach (var record in addedRecords)
            {
                Console.WriteLine($"Id: {record.Id}, Имя: {record.Name}, Фамилия: {record.LastName}, " +
                                $"Отчество: {record.Surname}, Дата рождения: {record.DateBirth:dd.MM.yyyy}, Номер телефона: {record.PhoneNumber}");
            }

            Console.WriteLine("Deleted records:");
            foreach (var record in deletedRecords)
            {
                Console.WriteLine($"Id: {record.Id}, Имя: {record.Name}, Фамилия: {record.LastName}, " +
                                $"Отчество: {record.Surname}, Дата рождения: {record.DateBirth:dd.MM.yyyy}, Номер телефона: {record.PhoneNumber}");
            }

            Console.WriteLine("Modified records:");
            foreach (var record in modifiedRecords)
            {
                var originalRecord = records1.Single(p => p.Id == record.Id);
                var modifiedFields = GetModifiedFields(originalRecord, record);
                Console.WriteLine($"Id: {record.Id}, Измененные поля: {string.Join(", ", modifiedFields)}");
            }
        }

        private static List<string> GetModifiedFields(PersonEntity originalRecord, PersonEntity modifiedRecord)
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
