using MyProject.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MyProject.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly MyProjectDbContext _context;

        public InitialHostDbBuilder(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
