using System;
using System.Collections.Generic;
using System.IO;
using SensibleDevTask.Entities;

namespace SensibleDevTask.Services
{
    public static class FileReader
    {
        public static List<PersonEntity> ReadCsvFile(string filePath)
        {
            var records = new List<PersonEntity>();
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл не найден: {filePath}");
            }
            
            using var reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(';');
                    
                    if (values.Length != 6)
                    {
                        Console.WriteLine($"Неверный формат данных в файле: {filePath}");
                    }

                    if (!int.TryParse(values[0], out int id))
                    {
                        Console.WriteLine($"Неверный формат данных в файле: {filePath}");
                    }

                    if (!DateTime.TryParse(values[4], out DateTime dateBirth))
                    {
                        Console.WriteLine($"Неверный формат данных в файле: {filePath}");
                    }
                    
                    var record = new PersonEntity
                    {
                        Id = id,
                        Name = values[1],
                        LastName = values[2],
                        Surname = values[3],
                        DateBirth = dateBirth,
                        PhoneNumber = values[5]
                    };

                    records.Add(record);
                }
            }

            return records;
        }
    }
}