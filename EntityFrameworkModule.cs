using System.Configuration;
using Castle.Core.Internal;
using SenseFramework.Core.Integrations;
using SenseFramework.Core.IoC;
using SenseFramework.Core.Messaging;

namespace SenseFramework.Data.EntityFramework
{
    public class EntityFrameworkModule : ITierApplicationModule
    {
        public void RegisterModule()
        {

            var migrationEnabled = ConfigurationManager.AppSettings["MigrationEnabled"];
            
            //register module installer with components. (repositories, intercepters)
            Messanger.Logger.Info("EntityFramework Core Data Module Installing...");
            IoCManager.Container.Install(new EntityFrameworkModuleInstaller());


            //if datamigration is enabled, proceed
            if (!migrationEnabled.IsNullOrEmpty() && migrationEnabled.Equals("TRUE", System.StringComparison.OrdinalIgnoreCase))
            {

            }


            Messanger.Logger.Info("EntityFramework Core Data Module Installed...");

        }
    }
}
