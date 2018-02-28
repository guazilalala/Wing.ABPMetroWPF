#if FEATURE_SIGNALR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.SignalR.Hubs;

namespace MyCompanyName.AbpZeroTemplate.Web.Startup
{
    public class SignalRAssemblyLocator : IAssemblyLocator
    {
        public IList<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).ToList();
        }
    }
}
#endif