
using CPRG005.Final.Api.ViewModels.Dock;

namespace CPRG005.Final.Api.ViewModels.Slip
{
    public class SlipDisplayViewModel
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public DockDisplayViewModel Dock { get; set; }
    }
}
