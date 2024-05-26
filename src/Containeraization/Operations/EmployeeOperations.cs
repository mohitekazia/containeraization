using Entities;
using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public interface IEmployeeOperations
    {

    }
    public class EmployeeOperations : RepositoryContext<Employee>,IEmployeeOperations
    {
        public EmployeeOperations(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
