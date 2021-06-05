﻿using CPRG005.Final.Roland.Models;
using CPRG005.Final.Roland.ViewModels;

namespace CPRG005.Final.Roland.Factories
{
    public interface IBoatFactory
    {
        Boat Build(CreateBoatViewModel model, int userId);
    }
    public class BoatFactory : IBoatFactory
    {
        public Boat Build(CreateBoatViewModel model, int customerId)
        {
            return new Boat()
            {
                RegistrationNumber = model.RegistrationNumber,
                Manufacturer = model.Manufacturer,
                ModelYear = model.ModelYear,
                Length = model.Length,
                CustomerId = customerId
            };
        }
    }
}
