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
        IQueryable<Employee> Get(int id);
    }
    public class EmployeeOperations : RepositoryContext<Employee>,IEmployeeOperations
    {
        public EmployeeOperations(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
