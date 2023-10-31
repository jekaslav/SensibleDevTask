using System.Collections.Generic;

namespace SensibleDevTask.Services
{
    public class PersonEntityComparer : IEqualityComparer<PersonEntity>
    {
        public bool Equals(PersonEntity x, PersonEntity y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(PersonEntity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}