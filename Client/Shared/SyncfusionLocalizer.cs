using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace OrisonCollegePortal.Client.Shared
{
    public class SyncfusionLocalizer : ISyncfusionStringLocalizer
    {
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key)!;
        }

        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                // Replace the ApplicationNamespace with your application name.
                // return Client.Resources.SfResources.ResourceManager;
                return OrisonCollegePortal.Client.Resources.SfResources.ResourceManager;
            }
        }
    }
}
