using Dapper;
using Sample_Dapper;
using System.Data.SqlClient;
namespace Sample_Dapper


{
 public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-SFJ3E08\\SQLEXPRESS;Database=Speehive;Integrated Security=True;";
            using (var conn = new SqlConnection(connectionString))
            {
                var helper = new Helper();
                conn.Open();
                var emp = new Employees
                {
                    EmpName = "Geo",
                    City = "Thrissur",
                    Salary = 10
                };

                helper.Insertion(conn, emp);


                // Delete employee "Geo"
                helper.Deletion(conn, "Geo");
                // Retrieving employee 

                var retrievedEmployee = helper.Retrival(conn, "mridual");

                // Printing retrieved employee details
                if (retrievedEmployee != null)
                {
                    Console.WriteLine($"Retrieved Employee: {retrievedEmployee.EmpName}, City: {retrievedEmployee.City}," +
                        $" Salary: {retrievedEmployee.Salary}");

                    // Updating the salary of employee 

                    int rowsAffected = helper.Updation(conn, "mridual", 1000);

                    Console.WriteLine($"Rows updated: {rowsAffected}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }


            }
        }
    }
}
