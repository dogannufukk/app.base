using AppProject.Application;
using AppProject.Application.Validator.Abstract;
using AppProject.Persistence;
using AppProject.Persistence.Context;
using AppProject.WebApi.Filter;
using AppProject.WebApi.Middleware;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AppProject.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers(opt =>
            {
                // ValidationFilter => Yapýlan http isteklerinde araya girerek istekler çalýþmadan önce filtrede kontrol saðlanýr.
                // ValidationFilter sayesinde Api'ye gönderilen objelerdeki validasyon hatalarýnýn mesajlarý geri kullanýcýya yansýr.
                opt.Filters.Add(typeof(ValidationFilter));
            })
           .AddFluentValidation(x =>
           {
               // FluentValidasyon iþlemlerini hangi Assembly dosyasýný içeren projede çalýþtýrdýðýmýzý belirttiðimiz yerdir. <> içerisine yazdýðýmýz class'ýn proje içerisindeki konumunda tüm FluentValidation alanlarýnýn kontrolü otomatik olarak saðlanýr.
               x.RegisterValidatorsFromAssemblyContaining<IValidator>();
           });
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                // Api'ye yapýlan isteklerde otomatik olarak ModelState'i kontrol edip hata alýndýðýnda 400 yanýtýný dönmesini devre dýþý býraktýk. Yukarýda uyguladýðýmýz validasyon filtresi ile artýk validasyon hatasý sonrasý, 400 yanýtýný validasyon filtremiz bizlere saðlamaktadýr.
                opt.SuppressModelStateInvalidFilter = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppProject.WebApi", Version = "v1" });
            });

            services.AddDbContext<MsSqlDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MsSql"));

            });

            services.AddCors(x =>
            {
                x.AddPolicy("corspolicy",
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });
            });
            // Projeye sonradan eklenmiþ olan extend edilmiþ dependency'leri belirtir.
            services.AddPersistenceServiceRegistration();
            services.AddApplicationServiceRegistration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppProject.WebApi v1"));
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<RequestMiddleware>();
            app.UseMiddleware<ResponseMiddleware>();
            app.UseCors(
                builder =>
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                );
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
