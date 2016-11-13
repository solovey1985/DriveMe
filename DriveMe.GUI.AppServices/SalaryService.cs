using System;
using System.Collections.Generic;
using Bigly.Api.ApiServices;
using Bigly.API.ApiServices.Interfaces;
using Bigly.Domain.Models;
using Bigly.GUI.ViewModels;

namespace Bigly.API.ApiServices
{
    class SalaryService :BaseApiService<Salary>, ISalaryService
    {
        public void BatchUpdate(List<SalaryViewModel> salariesToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalaryViewModel> GetPerMonthByEmloyeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Update(SalaryViewModel salaryToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalaryViewModel> GetPerMonth()
        {
            throw new NotImplementedException();
        }
    }
}