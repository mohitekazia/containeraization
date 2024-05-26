using Entities;
using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public interface ICompanyOperations
    {

    }
    public class CompanyOperations : RepositoryContext<Company>,ICompanyOperations
    {
        public CompanyOperations(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
