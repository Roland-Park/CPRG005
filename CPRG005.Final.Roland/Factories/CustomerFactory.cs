using CPRG005.Final.Roland.Models;
using CPRG005.Final.Roland.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.Roland.Factories
{
    public interface ICustomerFactory
    {
        Customer BuildForEdit(EditCustomerViewModel model, int customerId);
    }
    public class CustomerFactory : ICustomerFactory
    {
        public Customer BuildForEdit(EditCustomerViewModel model, int customerId)
        {
            return new Customer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                City = model.City,

            };           
        }
    }
}
