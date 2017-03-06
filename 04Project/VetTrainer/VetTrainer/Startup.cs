using Microsoft.Owin;
using MySql.Data.Entity;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(VetTrainer.Startup))]
namespace VetTrainer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }
    }
}
