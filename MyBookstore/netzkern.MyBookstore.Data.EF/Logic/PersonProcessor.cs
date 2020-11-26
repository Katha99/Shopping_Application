
using System.Collections.Generic;

using netzkern.MyBookstore.Data.EF.DataAccess;
using netzkern.MyBookstore.Data.EF.Models;

namespace netzkern.MyBookstore.Data.EF.Logic
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
