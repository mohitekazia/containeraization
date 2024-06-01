using Entities;
using Operations;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IEmployeeService
    {
        void Create(Employee employee);
        IEnumerable<Employee> Get(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryOperation _repositoryOperation;
        public EmployeeService(IRepositoryOperation repositoryOperation)
        {
            this._repositoryOperation = repositoryOperation;
        }
        public void Create(Employee employee)
        {
            try
            {
                this._repositoryOperation.employeeOperations.Create(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> Get(int id)
        {
            try
            {
               return this._repositoryOperation.employeeOperations.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
