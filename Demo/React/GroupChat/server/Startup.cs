using System.Collections.Generic;
using System.IO;
using DotNetify;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication
{
   public class Startup
   {
      /// <summary>
      ///    This method gets called by the runtime. Use this method to configure the
      ///    HTTP request pipeline.
      /// </summary>
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         app.UseWebSockets();
         app.UseSignalR(routes => routes.MapDotNetifyHub());

         app.UseDotNetify(
            config =>
            {
               config.UseMiddleware<GroupNameMiddleware>();
            }
         );

         if (env.IsDevelopment())
         {
            UseWebpack(app);
         }

         app.UseStaticFiles();

         app.Run(
            async context =>
            {
               using (var reader
                  = new StreamReader(File.OpenRead("wwwroot/index.html")))
               {
                  await context.Response.WriteAsync(reader.ReadToEnd());
               }
            }
         );
      }

      /// <summary>
      ///    This method gets called by the runtime. Use this method to add services to
      ///    the container.
      /// </summary>
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMemoryCache();
         services.AddSignalR();
         services.AddDotNetify();
      }

      private static void UseWebpack(IApplicationBuilder app)
      {
         app.UseWebpackDevMiddleware(
            new WebpackDevMiddlewareOptions
            {
               HotModuleReplacement = true
             , HotModuleReplacementClientOptions
                  = new Dictionary<string, string>
                  {
                     {
                        "reload", "true"
                     }
                  }
            }
         );
      }
   }
}