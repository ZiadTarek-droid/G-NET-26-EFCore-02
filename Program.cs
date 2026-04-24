namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            context.Database.EnsureCreated();

            Console.WriteLine("Database Created Successfully!");
        }
    }
    }

