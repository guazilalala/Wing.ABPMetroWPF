using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace Wing.ABPMetroWPF
{
	[DependsOn(typeof(AbpZeroCoreModule))]
	public class ABPMetroWPFCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
