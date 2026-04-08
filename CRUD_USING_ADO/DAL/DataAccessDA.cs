using CRUD_USING_ADO.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CRUD_USING_ADO.DAL
{
    public class DataAccessDA
    {

        public readonly string _ConnectionString;

        public DataAccessDA(IConfiguration configration) {

            _ConnectionString = configration.GetConnectionString("DefaultConnection");
        
        }

        public List<Employee> GetAllDat()
        {

            List<Employee> employee = new List<Employee>();

            SqlConnection conn = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("select * from employee" ,  conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {

                employee.Add(new Employee
                {
                    Empid = Convert.ToInt32(reader["EmpId"]),
                    EmpName = Convert.ToString(reader["EmpName"]),
                    Email = Convert.ToString(reader["Email"]),
                    Age = Convert.ToInt32(reader["Age"]),
                });
            
            }

            return employee;

        }


        //inset
        public void Insert(Employee ee) { 

            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("insert into employee(EmpName,Email,Age) values(@EmpName,@Email,@Age)", connection);

            cmd.Parameters.AddWithValue("EmpName",ee.EmpName);
            cmd.Parameters.AddWithValue("Email", ee.Email);
            cmd.Parameters.AddWithValue("Age", ee.Age);

            connection.Open();
            cmd.ExecuteNonQuery();

        
        }

        public Employee GetElementById(int Empid) { 

            Employee employee= new Employee();  

            SqlConnection connection = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from employee where Empid=@Empid ", connection);

            cmd.Parameters.AddWithValue("EmpId", Empid);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {

                employee.Empid = Convert.ToInt32(reader["Empid"]);
                employee.EmpName = Convert.ToString(reader["EmpName"]);
                employee.Email = Convert.ToString(reader["Email"]);
                employee.Age = Convert.ToInt32(reader["Age"]);

            }

            return employee;
        }

        public void update(Employee ee)
        {

            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("update employee set EmpName=@EmpName,Email=@Email,Age=@Age where EmpId=@EmpId", connection);

            cmd.Parameters.AddWithValue("@EmpId", ee.Empid);
            cmd.Parameters.AddWithValue("EmpName", ee.EmpName);
            cmd.Parameters.AddWithValue("Email", ee.Email);
            cmd.Parameters.AddWithValue("Age", ee.Age);

            connection.Open();
            cmd.ExecuteNonQuery();


        }


        public void delete(int EmplId) {

            SqlConnection conn = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("Delete from employee where EmpId=@EmpId", conn);
            cmd.Parameters.AddWithValue("@EmpId", EmplId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
