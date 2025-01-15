using Entities;
using Operations;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IEmployeeService
    {
        void Create(Employee employee);
        Employee Get(int id);

        IEnumerable<Employee> GetAllEmployees();
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

        public Employee Get(int id)
        {
            try
            {
               return this._repositoryOperation.employeeOperations.GetEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return this._repositoryOperation.employeeOperations.GetAll();
        }
    }
}
