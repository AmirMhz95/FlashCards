using DataBases;
using System.Data.SqlClient;
using UI;





internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Data Source=(LocalDb)\\LocalDbDemo;Initial Catalog=FlashCards; Integrated Security=True";
        using (var connection = new SqlConnection(connectionString))

            try
            {
                connection.Open();
                IDatabaseInitiliazer flashCardsInitializer = new FlashCardsTableInitializer();
                IDatabaseInitiliazer stacksInitializer = new StacksTableInitiliazer();
                stacksInitializer.Create();
                flashCardsInitializer.Create();
                Console.WriteLine("Connection to the database was successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        Menu menu = new Menu();
        menu.ShowMenu();

        int userChoice = int.Parse(Console.ReadLine());

        while (true)
        {
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("You chose to add a new stack");
                    break;
                case 2:
                    Console.WriteLine("You chose to add a new flashcard");
                    break;
                case 3:
                    Console.WriteLine("You chose to edit a stack");
                    break;
                case 4:
                    Console.WriteLine("You chose to edit a flashcard");
                    break;
                case 5:
                    Console.WriteLine("You chose to delete a stack");
                    break;
                case 6:
                    Console.WriteLine("You chose to delete a flashcard");
                    break;
                case 7:
                    Console.WriteLine("You chose to show all stacks");
                    break;
                case 8:
                    Console.WriteLine("You chose to show all flashcards");
                    break;
                case 9:
                    Console.WriteLine("You chose to exit");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, choose one of the numbers");
                    break;
            }


        }
    }
}