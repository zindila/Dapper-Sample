using Dapper;
using System.Data.SqlClient;
namespace Sample_Dapper
{
    public class Helper
    {
        public void Insertion(SqlConnection conn, Employees emp)
        {
            string insertQuery = "INSERT INTO Employee (EmpName,City,Salary) VALUES (@EmpName, @City, @Salary);";
            conn.Execute(insertQuery, emp);
        }

        public void Deletion(SqlConnection conn, string empName)
        {
            string deleteQuery = "DELETE FROM Employee WHERE EmpName = @EmpName;";
            conn.Execute(deleteQuery, new { EmpName = empName });
        }
        public Employees Retrival(SqlConnection conn, string empName)
        {
            string retrieveQuery = "SELECT * FROM Employee WHERE EmpName = @EmpName;";
            return conn.QueryFirstOrDefault<Employees>(retrieveQuery, new { EmpName = empName });
        }
        public int Updation(SqlConnection conn, string empName, decimal newSalary)
            {
            string updateQuery = "UPDATE Employee SET Salary = @Salary WHERE EmpName = @EmpName;";
            return conn.Execute(updateQuery, new { Salary = newSalary, EmpName = empName });
        }
    }
}

