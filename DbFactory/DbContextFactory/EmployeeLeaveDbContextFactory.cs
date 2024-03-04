using DatabaseContext;
using DbFactory.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbFactory.DbContextFactory
{
    public class EmployeeLeaveDbContextFactory : IDbContextsFactory
    {
        private EmployeeLeaveDbContext employeeLeaveInstance;

        public EmployeeLeaveDbContext CreateEmployeeLeaveDbContext(string connectionString)
        {
            
           if (employeeLeaveInstance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EmployeeLeaveDbContext>();
                var serviceVersion = new MySqlServerVersion(new Version(8, 0, 36));
                optionsBuilder.UseMySql(connectionString, serviceVersion);
                employeeLeaveInstance = new EmployeeLeaveDbContext(optionsBuilder.Options);
            }

            return employeeLeaveInstance;
    }
    }
}
