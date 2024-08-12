using Microsoft.Extensions.Configuration;
using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IHealthCheck
    {
        bool IsConnectionAvailable();
        string GetConnectionString();

        string GetEnvironment();
    }
    public class HealthCheckService : IHealthCheck
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public HealthCheckService(DataContext dataContext, IConfiguration configuration)
        {
            this._dataContext = dataContext;
            this._configuration = configuration;
        }
        
        public string GetConnectionString()
        {
            return this._configuration.GetSection("DatabaseConnString").Value;
        }

        
        public bool IsConnectionAvailable()
        {
           return this._dataContext.Database.CanConnect();
        }

        public string GetEnvironment()
        {
            return this._configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value;
        }
    }
}
