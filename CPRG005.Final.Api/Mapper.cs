using AutoMapper;
using CPRG005.Final.Api.ViewModels.Authorize;
using CPRG005.Final.Api.ViewModels.Boat;
using CPRG005.Final.Api.ViewModels.Customer;
using CPRG005.Final.Api.ViewModels.Dock;
using CPRG005.Final.Api.ViewModels.Lease;
using CPRG005.Final.Api.ViewModels.LeaseType;
using CPRG005.Final.Api.ViewModels.Location;
using CPRG005.Final.Api.ViewModels.Slip;
using CPRG005.Final.Domain.Entities;

namespace CPRG005.Final.Api
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Authorize, AuthorizeDisplayViewModel>();
            CreateMap<AuthorizeDisplayViewModel, Authorize>();

            CreateMap<Boat, BoatDisplayViewModel>();
            CreateMap<BoatDisplayViewModel, Boat>();

            CreateMap<Customer, CustomerDisplayViewModel>();
            CreateMap<CustomerDisplayViewModel, Customer>();

            CreateMap<Dock, DockDisplayViewModel>();
            CreateMap<DockDisplayViewModel, Dock>();

            CreateMap<Lease, LeaseDisplayViewModel>();
            CreateMap<LeaseDisplayViewModel, Lease>();

            CreateMap<LeaseType, LeaseTypeDisplayViewModel>();
            CreateMap<LeaseTypeDisplayViewModel, LeaseType>();

            CreateMap<Location, LocationDisplayViewModel>();
            CreateMap<LocationDisplayViewModel, Location>();

            CreateMap<Slip, SlipDisplayViewModel>();
            CreateMap<SlipDisplayViewModel, Slip>();
        }
    }
}
