using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SensibleDevTask.Services;

namespace SensibleDevTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader(args[0]);
            var records1 = fileReader.ReadCsvFile();

            fileReader = new FileReader(args[1]);
            var records2 = fileReader.ReadCsvFile();
    
            var fileComparison = new FileComparison(records1, records2);
    
            var resultPrinter = new ResultPrinter(fileComparison, records1);
            
            resultPrinter.PrintComparisonResults();
        }

    }
}

