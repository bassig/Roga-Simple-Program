using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roga_Simple_Program
{
    public sealed class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.Age).Name("Age");
            Map(m => m.Weight).Name("Weight(lbs)");
            Map(m => m.Gender).Name("Gender");
        }
    }

}
