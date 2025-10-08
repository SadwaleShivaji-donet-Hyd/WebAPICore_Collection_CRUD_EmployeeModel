using WebAPICore_Collection_CRUD_EmployeeModel.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebAPICore_Collection_CRUD_EmployeeModel.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){ Id=1, Name="Akhil", Department="IT",MobileNo="9012809213",Email="Akhil@gmail.com" },
            new Employee(){ Id=2, Name="Suraj ", Department = "IT", MobileNo = "9012809213",Email = "Suraj@gmail.com" },
            new Employee(){ Id=3, Name="Murthy", Department = "Finance", MobileNo = "9019809213" ,Email = "Murthy@gmail.com"}
        };
        public void AddEmployee(Employee employee)
        {  
            employees.Add(employee);

        }

        public void DeleteEmployee(int id)
        {
          var emp= employees.FirstOrDefault(e => e.Id == id);
            if(emp != null)
            {
                employees.Remove(emp);
            }
        }

        //checking if employees exists

        public bool Exists(int id)
        {
            return employees.Any(e => e.Id == id);
            
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
           return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var emp= employees.FirstOrDefault(e => e.Id == id);
            return emp;
        }

        public IEnumerable<Employee> GetEmployeesByDept(string dept)
        {
            var emp= employees.Where(e => e.Department == dept).ToList();
            return emp;
        }

        public void UpdateEmployee(Employee employee)
        {
            var emp= employees.FirstOrDefault(e => e.Id == employee.Id);
            if(emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
                emp.MobileNo = employee.MobileNo;
                emp.Email = employee.Email;
            }

        }

        public void UpdateEmployeeEmail(int id, string email)
        {
          var emp= employees.FirstOrDefault(e => e.Id == id);
            if(emp != null)
            {
                emp.Email = email;
            }
        }
    }
}
