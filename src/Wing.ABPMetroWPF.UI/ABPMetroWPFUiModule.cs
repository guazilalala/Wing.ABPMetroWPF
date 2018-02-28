using System.Reflection;
using Abp.Modules;

namespace Wing.ABPMetroWPF.UI
{
    [DependsOn(typeof(ABPMetroWPFDataModule), typeof(ABPMetroWPFApplicationModule))]
    public class ABPMetroWPFUiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
