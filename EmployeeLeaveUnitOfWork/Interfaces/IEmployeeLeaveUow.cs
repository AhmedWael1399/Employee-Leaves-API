using DatabaseContext;

namespace EmployeeLeaveUnitOfWork.Interfaces
{
    public interface IEmployeeLeaveUow
    {
        EmployeeLeaveDbContext GetEmployeeLeaveContext();
        void SaveChanges();
    }
}
