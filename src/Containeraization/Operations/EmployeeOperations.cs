using Entities;
using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public interface IEmployeeOperations
    {
        void Create(Employee entity);
        Employee GetEmployee(int id);
    }
    public class EmployeeOperations : RepositoryContext<Employee>,IEmployeeOperations
    {
        public EmployeeOperations(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Employee> GetAll()
        {
            return base.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return base.GetAll().FirstOrDefault(s => s.Id == id);
        }
    }
}
