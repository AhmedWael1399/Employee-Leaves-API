using DatabaseContext;
using DbFactory.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EmployeeLeaveUnitOfWork
{
    public class EmployeeLeaveUow : IEmployeeLeaveUow
    {
        private readonly IDbContextsFactory _context;
        private readonly IConfiguration _configuration;
        public EmployeeLeaveUow(IDbContextsFactory context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public EmployeeLeaveDbContext GetEmployeeLeaveContext()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return _context.CreateEmployeeLeaveDbContext(connectionString);
        }

        public void SaveChanges()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            _context.CreateEmployeeLeaveDbContext(connectionString).SaveChanges();
        }
    }
}
