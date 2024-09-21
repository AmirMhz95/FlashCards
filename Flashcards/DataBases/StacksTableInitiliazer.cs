using System.Data.SqlClient;
using Dapper;

namespace DataBases
{
    public class StacksTableInitiliazer : IDatabaseInitiliazer
    {
        public void Create()
        {
            string connectionString = "Data Source=(LocalDb)\\LocalDbDemo;Initial Catalog=FlashCards; Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                  IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Stacks' AND xtype='U')
                  CREATE TABLE Stacks (
                  Name NVARCHAR(255) PRIMARY KEY)";

                connection.Execute(createTableQuery);


            }
        }
    }
}
