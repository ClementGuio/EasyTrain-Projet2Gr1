using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddControllersWithViews(); // Permet d'utiliser les controller avec vues
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (BddContext ctx = new BddContext()) //Appel de la méthode de création et remplisssage de la bdd
            {
                ctx.InitializeDb();
            }

            app.UseRouting();

            app.UseStaticFiles(); // Permet d'utiliser les fichiers statiques de wwwroot

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(  //Ajout d'une route par défaut
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
