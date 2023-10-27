using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTrain_P2Gr1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login/Connexion";
            });
            services.AddControllersWithViews(); // Permet d'utiliser les controller avec vues
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (BddContext ctx = new BddContext()) //Appel de la m�thode de cr�ation et remplisssage de la bdd
            {
                ctx.InitializeDb();
            }

            app.UseRouting(); // ????

            app.UseStaticFiles(); // Permet d'utiliser les fichiers statiques de wwwroot

            app.UseAuthentication(); //Permet d'utiliser l'authentification
            
            app.UseAuthorization(); // Permet d'utiliser les autorisations selon les roles

            app.UseEndpoints(endpoints => // Permet de redéfinir le routing
            {
                endpoints.MapControllerRoute(  //Ajout d'une route par d�faut
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
