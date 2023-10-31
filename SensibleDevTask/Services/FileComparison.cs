using System.Collections.Generic;
using System.Linq;

namespace SensibleDevTask.Services
{
    public class FileComparison
    {
        private List<PersonEntity> _records1;
        private List<PersonEntity> _records2;

        public FileComparison(List<PersonEntity> records1, List<PersonEntity> records2)
        {
            _records1 = records1;
            _records2 = records2;
        }

        public List<PersonEntity> GetAddedRecords()
        {
            var addedRecords = _records2.Except(_records1, new PersonEntityComparer()).ToList();
            return addedRecords;
        }

        public List<PersonEntity> GetDeletedRecords()
        {
            var deletedRecords = _records1.Except(_records2, new PersonEntityComparer()).ToList();
            return deletedRecords;
        }

        public List<PersonEntity> GetModifiedRecords()
        {
            var modifiedRecords = _records2.Intersect(_records1, new PersonEntityComparer())
                .Where(r => !r.Equals(_records1.Single(p => p.Id == r.Id))).ToList();
            return modifiedRecords;
        }
    }
}