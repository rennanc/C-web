using MVCtrab.Models;
using Owin;

namespace MVCtrab
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure o contexto db, gerenciador de usuários e gerenciador de login para usar uma única instância por solicitação
            app.CreatePerOwinContext(ApplicationDbContext.Create);
          
        }
    }
}