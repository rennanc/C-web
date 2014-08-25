using MVCtrab.Models;
using Owin;

namespace MVCtrab
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configuração do contexto db
            app.CreatePerOwinContext(ApplicationDbContext.Create);
          
        }
    }
}