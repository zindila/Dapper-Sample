using Dapper;
using Sample_Dapper;
using System.Data.SqlClient;


namespace Sample_Dapper


{
    internal class Program
    {
        static void Main(string[] args)
        {
           string connectionString = "Server=DESKTOP-SFJ3E08\\SQLEXPRESS;Database=Speehive;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            var emp = new Employees
            {
                EmpName = "Geo",
                City = "Thrissur",
                Salary = 10
            };

            string insertQuery = "INSERT INTO Employee (EmpName,City,Salary) VALUES (@EmpName, @City, @Salary);";
            conn.Execute(insertQuery, emp);

            // Delete employee "Geo"
            string deleteQuery = "DELETE FROM Employee WHERE EmpName = @EmpName;";
            conn.Execute(deleteQuery, new { EmpName = "Geo" });

            // Retrieving employee 
            string retrieveQuery = "SELECT * FROM Employee WHERE EmpName = @EmpName;";
            var retrievedEmployee = conn.QueryFirstOrDefault<Employees>(retrieveQuery, new { EmpName = "mridual" });

            // Printing retrieved employee details
            if (retrievedEmployee != null)
            {
                Console.WriteLine($"Retrieved Employee: {retrievedEmployee.EmpName}, City: {retrievedEmployee.City}," +
                    $" Salary: {retrievedEmployee.Salary}");

                // Updating the salary of employee 
                string updateQuery = "UPDATE Employee SET Salary = @Salary WHERE EmpName = @EmpName;";
                int rowsAffected = conn.Execute(updateQuery, new { Salary = 10000, EmpName = "mridual" });

                Console.WriteLine($"Rows updated: {rowsAffected}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }


        }
    }
}
