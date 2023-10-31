using System;
using System.Collections.Generic;
using System.IO;

namespace SensibleDevTask.Services
{
    public class FileReader
    {
        private string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<PersonEntity> ReadCsvFile()
        {
            var records = new List<PersonEntity>();
        
            using (var reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(';');

                        var record = new PersonEntity
                        {
                            Id = int.Parse(values[0]),
                            Name = values[1],
                            LastName = values[2],
                            Surname = values[3],
                            DateBirth = DateTime.Parse(values[4]),
                            PhoneNumber = values[5]
                        };

                        records.Add(record);
                    }
                }
            }
        
            return records;
        }
    }
}