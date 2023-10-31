using CsvHelper.Configuration;

namespace SensibleDevTask
{
    public sealed class PersonMap : ClassMap <PersonEntity>
    {
        public PersonMap()
        {
            Map(x => x.Name).Name("Name");
            Map(x => x.LastName).Name("LastName");
            Map(x => x.Surname).Name("Surname");
            Map(x => x.DateBirth).Name("DateBirth");
            Map(x => x.PhoneNumber).Name("PhoneNumber");
        }
    }
}