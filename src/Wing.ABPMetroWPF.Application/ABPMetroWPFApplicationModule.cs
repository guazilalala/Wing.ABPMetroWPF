using Abp.AutoMapper;
using Abp.Modules;
using System.Reflection;

namespace Wing.ABPMetroWPF
{
	[DependsOn(typeof(ABPMetroWPFCoreModule))]
	[DependsOn(typeof(AbpAutoMapperModule))]
	public class ABPMetroWPFApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
		}
    }
}
