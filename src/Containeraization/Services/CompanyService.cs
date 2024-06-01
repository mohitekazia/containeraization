using Entities;
using Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
    }
    public sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryOperation _repositoryOperation;
        public CompanyService(IRepositoryOperation repositoryOperation)
        {
            this._repositoryOperation = repositoryOperation;
        }
        public IEnumerable<Company> GetAllCompanies()
        {
            return this._repositoryOperation.companyOperations.GetAll();
        }
    }
}
