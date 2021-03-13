using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreTest
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // request->exceptionhandler->hsts->httpsredirection->
            // static files -> routing->cors->authentication->custom middlewares->endpoint

            // mvc: resource filters->model binding->model validation
            // -> action filter(user code)->exception filter->result filters

            app.UseDeveloperExceptionPage();
            //app.UseDatabaseErrorPage();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseRouting();
            //app.UseRequestLocalization();
            //app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();



            app.Use(async (context, next) =>
            {
                await next.Invoke();
            });

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello, world");
            //});

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();

                app.Map("/map1", app => {
                    app.Run(async context =>
                    {
                        await context.Response.WriteAsync("map test 1");
                    });
                });

                app.Map("/level1", level1App =>
                {
                    level1App.Map("/level2a", level2AApp =>
                    {
                        // /level1/level2a
                    });

                    level1App.Map("/level2b", level2BApp =>
                    {
                        // /level1/level2a
                    });
                });



                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from non-Map delegate");
                });
            });


            
        }
    }
}
