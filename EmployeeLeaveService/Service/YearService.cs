using EmployeeLeaveService.Interfaces;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.YearDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveService.Service
{
    public class YearService : IYearService
    {
        private readonly IYearRepository _yearRepository;
        private readonly IEmployeeLeaveUow _unitOfWork;

        public YearService(IYearRepository yearRepository, IEmployeeLeaveUow unitOfWork)
        {
            _yearRepository = yearRepository;
            _unitOfWork = unitOfWork;
        }
        public Year CreateYear(Year year)
        {
            _yearRepository.CreateYear(year);
            _unitOfWork.SaveChanges();
            return year;
        }

        public void DeleteYear(int yearId)
        {
            _yearRepository.DeleteYear(yearId);
            _unitOfWork.SaveChanges();
        }

        public YearDto GetYearById(int yearId)
        {
            return _yearRepository.GetYearById(yearId);
        }

        public YearDto GetYearByValue(int yearValue)
        {
            return _yearRepository.GetYearByValue(yearValue);
        }

        public List<YearDto> GetYears()
        {
            return _yearRepository.GetYears();
        }

        public Year UpdateYear(Year year)
        {
            _yearRepository.UpdateYear(year);
            _unitOfWork.SaveChanges();
            return year;
        }

        public bool YearExists(int yearId)
        {
            return _yearRepository.YearExists(yearId);
        }
    }
}
