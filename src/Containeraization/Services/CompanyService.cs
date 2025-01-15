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
        Company Get(int id);
    }
    public sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryOperation _repositoryOperation;
        public CompanyService(IRepositoryOperation repositoryOperation)
        {
            this._repositoryOperation = repositoryOperation;
        }

        public Company Get(int id)
        {
            return this._repositoryOperation.companyOperations.GetCompany(id);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return this._repositoryOperation.companyOperations.GetAll();
        }
    }
}
