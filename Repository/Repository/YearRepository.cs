using DatabaseContext;
using DbFactory.Interfaces;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.YearDtos;

namespace EmployeeLeavesRepository.Repository
{
    public class YearRepository : IYearRepository
    {
        private readonly EmployeeLeaveDbContext employeeLeaveContext;
        public YearRepository(IEmployeeLeaveUow unitOfwork)
        {
            employeeLeaveContext = unitOfwork.GetEmployeeLeaveContext();
        }
        public Year CreateYear(Year year)
        {
            employeeLeaveContext.Years.Add(year);
            return year;
        }

        public void DeleteYear(int yearId)
        {
            var year = employeeLeaveContext.Years.FirstOrDefault(y => y.Id == yearId);
            if (year != null)
            {
                employeeLeaveContext.Years.Remove(year);
            }
        }

        public YearDto GetYearById(int yearId)
        {
           YearDto year = employeeLeaveContext.Years.Where(year => year.Id == yearId).Select(year => new YearDto
           {
               Id = yearId,
               YearValue = year.YearValue
           }).FirstOrDefault()!;
            return year;
        }

        public YearDto GetYearByValue(int yearValue)
        {
            YearDto year = employeeLeaveContext.Years.Where(year => year.YearValue == yearValue).Select(year => new YearDto
            {
                Id = year.Id,
                YearValue = year.YearValue
            }).FirstOrDefault()!;
            return year;
        }

        public List<YearDto> GetYears()
        {
            List<YearDto> years = employeeLeaveContext.Years
                .Select(year => new YearDto
                {
                    Id = year.Id,
                    YearValue = year.YearValue
                }).ToList();
            return years;
        }

        public Year UpdateYear(Year year)
        {
            employeeLeaveContext.Years.Update(year);
            return year;
        }

        public bool YearExists(int yearId)
        {
            return employeeLeaveContext.Years.Any(y => y.Id == yearId);
        }
    }
}
