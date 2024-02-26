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

        }
    }
}
