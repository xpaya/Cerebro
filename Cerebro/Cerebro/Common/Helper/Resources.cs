using Windows.ApplicationModel.Resources;

namespace Cerebro.Common.Helper
{
    public static class Resources
    {
        private static ResourceLoader _resources;
        private static ResourceLoader resource
        {
            get
            {
                _resources = _resources ?? ResourceLoader.GetForCurrentView();
                return _resources;
            }
        }
        public static string GetResource(string keyResource)
        {
            var result  = resource.GetString(keyResource);

            return result;
        }
    }
}