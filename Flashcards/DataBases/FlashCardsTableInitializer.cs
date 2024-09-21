using System.Data.SqlClient;
using Dapper;

namespace DataBases
{
    public class FlashCardsTableInitializer : IDatabaseInitiliazer
    {
        public void Create()
        {
            string connectionString = "Data Source=(LocalDb)\\LocalDbDemo;Initial Catalog=FlashCards; Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                     IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Flashcards' AND xtype='U')
                     CREATE TABLE Flashcards (
                     Id INT PRIMARY KEY IDENTITY(1,1),
                     StackName NVARCHAR(255) NOT NULL,
                     Question NVARCHAR(255) NOT NULL,
                     Answer NVARCHAR(255) NOT NULL,
                     FOREIGN KEY (StackName) REFERENCES Stacks(Name)
)";

                connection.Execute(createTableQuery);
            }

        }
    }
}
