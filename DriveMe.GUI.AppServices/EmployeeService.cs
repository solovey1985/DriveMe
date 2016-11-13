using System;
using System.Collections.Generic;
using Bigly.DAL.Repositories;
using Bigly.Domain.Models;
using Driveme.Domain.Services.Factories;

namespace Bigly.Api.ApiServices
{
    public class EmployeeService:BaseApiService<Employee>
    {
        EmployeeFactory employeeFactory;
        public EmployeeService(BaseFactory<Employee> factory) : base(factory, new TripRepository())
        {
            employeeFactory = new EmployeeFactory();
        }

        public IEnumerable<Employee> GetAll()
        {
            return repository.GetAll();
        }

        public Employee GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public int Create(Employee trip)
        {
            trip = factory.Create(trip);
            repository.Insert(trip);
            return trip.Id;

        }

        public int Update(Employee trip)
        {
            repository.Update(trip);
            return trip.Id;
        }

        public void DeleteById(Guid id)
        {
            repository.DeleteById(id);
        }

        public void DeleteRoute(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalary(int EmployeeId, Salary salary)
        {
            throw new NotImplementedException();
        }

     
    }
}
