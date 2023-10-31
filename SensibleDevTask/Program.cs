using SensibleDevTask.Services;

namespace SensibleDevTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var records1 = FileReader.ReadCsvFile(args[0]);
            
            var records2 = FileReader.ReadCsvFile(args[1]);

            var addedRecords = FileComparison.GetAddedRecords(records1, records2);
            var deletedRecords = FileComparison.GetDeletedRecords(records1, records2);
            var modifiedRecords = FileComparison.GetModifiedRecords(records1, records2);
            
            
            ResultPrinter.PrintComparisonResults(addedRecords, deletedRecords, modifiedRecords, records1);
        }
    }
}

