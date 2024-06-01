﻿using Entities;
using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public interface ICompanyOperations
    {
        IEnumerable<Company> GetAll();

    }
    public class CompanyOperations : RepositoryContext<Company>,ICompanyOperations
    {
        public CompanyOperations(DataContext dataContext) : base(dataContext)
        {
        }
      
        public IEnumerable<Company> GetAll()
        {
            return base.GetAll();
        }
    }
}
