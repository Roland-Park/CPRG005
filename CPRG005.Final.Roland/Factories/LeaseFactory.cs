using CPRG005.Final.Roland.Models;
using CPRG005.Final.Roland.ViewModels;
using System;

namespace CPRG005.Final.Roland.Factories
{
    public interface ILeaseFactory
    {
        Lease Build(CreateLeaseViewModel model, int customerId);
    }
    public class LeaseFactory : ILeaseFactory
    {
        public LeaseFactory()
        {

        }
        public Lease Build(CreateLeaseViewModel model, int customerId)
        {
            return new Lease()
            {
                StartDate = model.Start,
                EndDate = SetEndDate(model),
                SlipId = model.SlipId,
                LeaseTypeId = model.LeaseTypeId,
                CustomerId = customerId
            };
        }

        private DateTime SetEndDate(CreateLeaseViewModel model)
        {
            DateTime end;
            switch (model.LeaseTypeId)
            {
                case 1:
                    end = model.Start.AddDays(1);
                    break;
                case 2:
                    end = model.Start.AddDays(7);
                    break;
                case 3:
                    end = model.Start.AddMonths(1);
                    break;
                case 4:
                    end = model.Start.AddYears(1);
                    break;
                default:
                    end = new DateTime();
                    break;
            }

            return end;
        }
    }
}
