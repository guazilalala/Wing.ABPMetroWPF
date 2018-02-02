using System.Reflection;
using Abp.Modules;

namespace Wing.ABPMetroWPF
{
    public class ABPMetroWPFCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
