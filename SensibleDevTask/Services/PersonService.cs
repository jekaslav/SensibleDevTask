using System;
using System.Collections.Generic;
using System.IO;

namespace SensibleDevTask
{
    public class PersonService
    {
        public List<PersonEntity> ReadCsvFile(string filePath)
        {
            var records = new List<PersonEntity>();

            using (var reader = new StreamReader(filePath))
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