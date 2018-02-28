using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Wing.ABPMetroWPF.EntityFramework;

namespace Wing.ABPMetroWPF
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(ABPMetroWPFCoreModule))]
    public class ABPMetroWPFDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<ABPMetroWPFDbContext>(null);
        }
    }
}
