using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class PersonProcessor
    {
        public static int CreatePerson(string firstName, string lastName, string emailAddress, string password)
        {
            Person data = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Password = password
            };

            string sql = @"insert into dbo.Persons (FirstName, LastName, EmailAddress, Password)
                            values (@FirstName, @LastName, @EmailAddress, @Password);";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<Person>  LoadPerson(string emailAddress)
        {
            string sql = @"select Id, FirstName, LastName, EmailAddress, Password
                            from dbo.Persons
                            where EmailAddress = '" + emailAddress + "';";
            return SQLDataAccess.LoadData<Person>(sql);
        }
    }
}
