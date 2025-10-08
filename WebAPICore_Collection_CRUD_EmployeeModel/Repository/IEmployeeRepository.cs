using WebAPICore_Collection_CRUD_EmployeeModel.Models;

namespace WebAPICore_Collection_CRUD_EmployeeModel.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        public void AddEmployee(Employee employee);
       public  void UpdateEmployee(Employee employee);
       public void DeleteEmployee(int id);
      public  void UpdateEmployeeEmail(int id, string email);
        IEnumerable<Employee> GetEmployeesByDept(string dept);
       public bool Exists(int id);
    }
}
