using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExpense.Models;
using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;
using System.IO;

namespace FinalExpense.Services
{
    public class CsvService
    {
       public string errorMessage = "My Message will be here";
       public IEnumerable<Records> ReadCsvFile(Stream fileStream)
        {
            try
            {
                using var reader = new StreamReader(fileStream);
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = new List<Records>();
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        var record = new Records
                        {
                            Date = csv.GetField<DateTime>("Date"),
                            SalesRep = csv.GetField("SalesRep"),
                            Status = csv.GetField("Status")
                        };
                        records.Add(record);
                    }
                    //var records = csv.GetRecords<Records>().ToList() ;
                    return records;
                }
            }
            catch (HeaderValidationException ex)
            {
                // Specific exception for header issues
                errorMessage = "CSV file header is invalid.";
                throw new ApplicationException(errorMessage, ex);

            }
            catch (TypeConverterException ex)
            {
                // Specific exception for type conversion issues
                errorMessage = "CSV file contains invalid data format.";
                throw new ApplicationException(errorMessage, ex);

            }
            catch (Exception ex)
            {
                // General exception for other issues
                errorMessage = "Error reading CSV file";
                throw new ApplicationException(errorMessage, ex);

            }
        }
    }
}

