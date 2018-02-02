using Wing.ABPMetroWPF.EntityFramework;
using Wing.ABPMetroWPF.People;
using System.Data.Entity.Migrations;

namespace Wing.ABPMetroWPF.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ABPMetroWPFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ABPMetroWPF";
        }

        protected override void Seed(ABPMetroWPFDbContext context)
        {
            context.People.AddOrUpdate(
                p => p.Name,
                new Person {Name = "Halil"},
                new Person {Name = "Emre"}
                );
        }
    }
}
