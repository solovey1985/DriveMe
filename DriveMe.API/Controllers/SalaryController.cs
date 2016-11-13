using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Bigly.Api.ApiServices;
using Bigly.API.ApiServices.Interfaces;
using Bigly.Domain.Models;
using Bigly.GUI.ViewModels;

namespace Bigly.API.Controllers
{

    public class SalaryController:ApiController
    {
        private ISalaryService _salaryService;

        public SalaryController() {}

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        public IEnumerable<SalaryViewModel> Get()
        {
            List<SalaryViewModel> salriesPerMonth = _salaryService.GetPerMonth().ToList();
            return salriesPerMonth;
        }

        public IEnumerable<SalaryViewModel> Get(int employeeId)
        {
            List<SalaryViewModel> salriesPerMonth = _salaryService.GetPerMonthByEmloyeeId(employeeId).ToList();
            return salriesPerMonth;
        }

        public SalaryViewModel Put(SalaryViewModel salaryToUpdate)
        {
            _salaryService.Update(salaryToUpdate);
            return salaryToUpdate;
        }

        public IEnumerable<SalaryViewModel> Put(List<SalaryViewModel> salariesToUpdate)
        {
            _salaryService.BatchUpdate(salariesToUpdate);
            return salariesToUpdate;
        }  
    }
}