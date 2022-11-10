using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class SQLEmployeeRepository : IsEmployeeRepository
    {
        private readonly MyAppDbContext context;

        public SQLEmployeeRepository(MyAppDbContext context)
        {
            this.context = context;
        }

        Employee IsEmployeeRepository.Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        Employee IsEmployeeRepository.Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        IEnumerable<Employee> IsEmployeeRepository.GetAllEmployees()
        {
            return context.Employees;
        }

        Employee IsEmployeeRepository.GetEmployee(int id)
        {
            return context.Employees.FirstOrDefault(m => m.Id == id);
        }

        Employee IsEmployeeRepository.Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
