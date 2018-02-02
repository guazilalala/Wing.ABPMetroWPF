using System.Reflection;
using Abp.Modules;
using Wing.ABPMetroWPF.People;
using Wing.ABPMetroWPF.People.Dto;
using AutoMapper;
using Abp.AutoMapper;

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
