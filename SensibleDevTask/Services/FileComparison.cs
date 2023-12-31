using System.Collections.Generic;
using System.Linq;
using SensibleDevTask.Entities;

namespace SensibleDevTask.Services
{
    public static class FileComparison
    {
        private static readonly PersonEntityComparer PersonEntityComparer = new();
        
        public static List<PersonEntity> GetAddedRecords(List<PersonEntity> records1, List<PersonEntity> records2)
        {
            var addedRecords = records2.Except(records1, PersonEntityComparer).ToList();
            return addedRecords;
        }

        public static List<PersonEntity> GetDeletedRecords(List<PersonEntity> records1, List<PersonEntity> records2)
        {
            var deletedRecords = records1.Except(records2, PersonEntityComparer).ToList();
            return deletedRecords;
        }

        public static List<PersonEntity> GetModifiedRecords(List<PersonEntity> records1, List<PersonEntity> records2)
        {
            var modifiedRecords = records2.Intersect(records1, PersonEntityComparer)
                .Where(r => !r.Equals(records1.Single(p => p.Id == r.Id))).ToList();
            return modifiedRecords;
        }
    }
}