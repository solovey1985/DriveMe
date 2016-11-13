using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Bigly.Api.ApiServices;
using Bigly.Domain.Models;

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

        public IEnumerable<Salary> Get()
        {
            List<Salary> salriesPerMonth = _salaryService.GetPerMonth().ToList();
            return salriesPerMonth;
        }

        public IEnumerable<Salary> Get(int employeeId)
        {
            List<Salary> salriesPerMonth = _salaryService.GetPerMonthByEmloyeeId(employeeId).ToList();
            return salriesPerMonth;
        }

        public Salary Put(Salary salaryToUpdate)
        {
            _salaryService.Update(salaryToUpdate);
            return salaryToUpdate;
        }

        public IEnumerable<Salary> Put(List<Salary> salariesToUpdate)
        {
            _salaryService.BatchUpdate(salariesToUpdate);
            return salariesToUpdate;
        }  
    }
}