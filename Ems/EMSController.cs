using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Ems
{
    public class EMSController
    {
        private MySqlConnection connection;

        public EMSController()
        {
            String connect = "server=localhost;Database=Ems;Uid=root;password=977327341426";
            connection = new MySqlConnection(connect);
        }
        public EMS AddEmployee(EMS emp)
        {
            connection.Open();

            String query = "Insert into employee(Name, Salary, Department) values(@name,@salary,@dept)";
            var cmd=new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary",emp.Salary);
            cmd.Parameters.AddWithValue("@dept",emp.Department);
            int res=cmd.ExecuteNonQuery();
            connection.Close();
            if (res > 0)
            {
                Console.WriteLine("Added");
                return emp;
           
            }
            else
            {
                Console.WriteLine("Not Added");
                return null;
               
            }


        }
        public bool UpdateEmployee(EMS emp)
        {
            connection.Open();
            string query = "UPDATE employee SET Name = @name, Salary = @salary, Department = @dept WHERE Id = @id";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id",emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@dept", emp.Department);
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            if (res > 0)
            {
                Console.WriteLine("Employee Updated");
                return true;
            }
            else
            {
                Console.WriteLine("Not Updated");
                return false;
            }

        }
        public void DeleteEmployee(EMS emp) {
            connection.Open();

            string query = "Delete from employee WHERE Id = @id";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            if (res > 0)
            {
                Console.WriteLine("Employee Deleted");
            }
            else
            {
                Console.WriteLine("Not Added");
                

            }
        }

        public List<EMS> viewAll() 
        {
            connection.Open();
            string query = "select * from employee";
            List<EMS> list = new List<EMS>();
            var cmd = new MySqlCommand(query, connection);
            var reader= cmd.ExecuteReader();
            while (reader.Read())
            {
                var EMS = new EMS
                {
                    Id = reader.GetInt32("id"),
                    Name= reader.GetString("name"),
                    Salary=reader.GetString("salary"),
                    Department=reader.GetString("department")
                };
                list.Add(EMS);  

            }
            reader.Close();
            connection.Close();

            return list;

        }

        public EMS ViewOne(int id) {
            connection.Open();
            string query = "select * from employee where Id=@id";
            var cmd = new MySqlCommand(query, connection);
            EMS empl = null;
            cmd.Parameters.AddWithValue("@id",id);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                empl = new EMS
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Salary = reader.GetString("salary"),
                    Department = reader.GetString("department")
                };
            }
            reader.Close();
            connection.Close();
            return empl;
        }
    }
}
