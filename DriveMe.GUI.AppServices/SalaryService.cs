using System;
using System.Collections.Generic;
using Bigly.Api.ApiServices;
using Bigly.API.ApiServices.Interfaces;
using Bigly.Domain.Models;

namespace Bigly.API.ApiServices
{
    class SalaryService :BaseApiService<Salary>, ISalaryService
    {
        public void BatchUpdate(List<Salary> salariesToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Salary> GetPerMonthByEmloyeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Update(Salary salaryToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Salary> GetPerMonth()
        {
            throw new NotImplementedException();
        }
    }
}