using Models;
using Models.Dtos.YearDtos;

namespace EmployeeLeavesRepository.Interfaces
{
    public interface IYearRepository
    {
        public List<YearDto> GetYears();
        public YearDto GetYearById(int yearId);
        public YearDto GetYearByValue(int yearValue);
        public Year CreateYear(Year year);
        public Year UpdateYear(Year year);
        public void DeleteYear(int yearId);
        public bool YearExists(int yearId);
    }
}
