using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.StaticFiles;

namespace SupplyDefenseRelease
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            StaticFileOptions option = new StaticFileOptions();
            FileExtensionContentTypeProvider contentTypeProvider = 
                (FileExtensionContentTypeProvider)option.ContentTypeProvider ?? new FileExtensionContentTypeProvider();

            contentTypeProvider.Mappings.Add(".unityweb", "application/octet-stream");
            option.ContentTypeProvider = contentTypeProvider;

            app.UseDefaultFiles();
            app.UseStaticFiles(option);
            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
