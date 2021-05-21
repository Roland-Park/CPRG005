using System.Configuration;

namespace CPRG005.Final.Roland.Helpers
{
    public interface IApplicationSettingsHelper
    {
        string ApiBaseUrl { get; }
    }
    public class ApplicationSettingsHelper : IApplicationSettingsHelper
    {
        public string ApiBaseUrl => ConfigurationManager.AppSettings["ApiBaseUrl"];
    }
}
