
namespace CPRG005.Final.Api.ViewModels.Dock
{
    public class DockDisplayViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public bool HasWaterService { get; set; }
        public bool HasElectricService { get; set; }
    }
}
