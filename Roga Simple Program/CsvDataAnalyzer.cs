using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roga_Simple_Program
{
    public class CsvDataAnalyzer
    {
        public static double GetAvgAgeFromCsv(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            using (CsvReader csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csvReader.Context.RegisterClassMap<PersonMap>();
                var records = csvReader.GetRecords<Person>();
                return records.Average(person => person.Age);
            }
        }

        public static int GetTotalBetweenWeightsFromCsv(string filePath, double minWeight, double maxWeight)
        {
            using (StreamReader reader = new StreamReader(filePath))
            using (CsvReader csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csvReader.Context.RegisterClassMap<PersonMap>();
                var records = csvReader.GetRecords<Person>();
                return records.Count(person => person.Weight >= minWeight && person.Weight <= maxWeight);
            }
        }

        public static double GetAvgAgeBetweenWeightsFromCsv(string filePath, double minWeight, double maxWeight)
        {
            using (StreamReader reader = new StreamReader(filePath))
            using (CsvReader csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csvReader.Context.RegisterClassMap<PersonMap>();
                var records = csvReader.GetRecords<Person>().Where(person => person.Weight >= minWeight && person.Weight <= maxWeight);
                return records.Any() ? records.Average(person => person.Age) : 0;
            }
        }
    }
}
