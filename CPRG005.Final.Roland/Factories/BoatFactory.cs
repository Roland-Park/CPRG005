using CPRG005.Final.Roland.Models;
using CPRG005.Final.Roland.ViewModels;

namespace CPRG005.Final.Roland.Factories
{
    public interface IBoatFactory
    {
        Boat Build(CreateBoatViewModel model, int customerId);
        Boat BuildForEdit(EditBoatViewModel model, int customerId);
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

        public Boat BuildForEdit(EditBoatViewModel model, int customerId)
        {
            return new Boat()
            {
                Id = model.BoatId,
                RegistrationNumber = model.RegistrationNumber,
                Manufacturer = model.Manufacturer,
                ModelYear = model.ModelYear,
                Length = model.Length,
                CustomerId = customerId
            };
        }
    }
}
