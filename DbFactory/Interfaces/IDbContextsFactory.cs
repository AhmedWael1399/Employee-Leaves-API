using DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DbFactory.Interfaces
{
    public interface IDbContextsFactory
    {
        EmployeeLeaveDbContext CreateEmployeeLeaveDbContext(string connectionString);
    }
}
