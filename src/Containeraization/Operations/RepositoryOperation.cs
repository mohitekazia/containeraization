using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public interface IRepositoryOperation
    {
       IEmployeeOperations employeeOperations { get; }
       ICompanyOperations companyOperations { get; }

        void Save();
    }
    public class RepositoryOperation : IRepositoryOperation, IDisposable
    {
        private readonly DataContext _dataContext;
        private readonly Lazy<ICompanyOperations> _companyOperations;
        private readonly Lazy<IEmployeeOperations> _employeeOperations;

        public RepositoryOperation(DataContext dataContext)
        {
            _dataContext = dataContext;
            _companyOperations = new Lazy<ICompanyOperations>(() => { return new CompanyOperations(dataContext); });
            _employeeOperations = new Lazy<IEmployeeOperations>(() => { return new EmployeeOperations(dataContext); });
        }

        public ICompanyOperations companyOperations => _companyOperations.Value;
        public IEmployeeOperations employeeOperations => _employeeOperations.Value;

        private bool IsDisposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    this._dataContext.Dispose();
                }
            }
            this.IsDisposed = true;

        }

        public void Save() => _dataContext.SaveChanges();
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
