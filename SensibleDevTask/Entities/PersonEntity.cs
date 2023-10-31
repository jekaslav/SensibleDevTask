using System;

namespace SensibleDevTask
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}