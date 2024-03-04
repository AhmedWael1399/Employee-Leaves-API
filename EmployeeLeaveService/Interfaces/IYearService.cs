using Models;
using Models.Dtos.YearDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveService.Interfaces
{
    public interface IYearService
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
