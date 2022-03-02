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
                // ValidationFilter => Yap�lan http isteklerinde araya girerek istekler �al��madan �nce filtrede kontrol sa�lan�r.
                // ValidationFilter sayesinde Api'ye g�nderilen objelerdeki validasyon hatalar�n�n mesajlar� geri kullan�c�ya yans�r.
                opt.Filters.Add(typeof(ValidationFilter));
            })
           .AddFluentValidation(x =>
           {
               // FluentValidasyon i�lemlerini hangi Assembly dosyas�n� i�eren projede �al��t�rd���m�z� belirtti�imiz yerdir. <> i�erisine yazd���m�z class'�n proje i�erisindeki konumunda t�m FluentValidation alanlar�n�n kontrol� otomatik olarak sa�lan�r.
               x.RegisterValidatorsFromAssemblyContaining<IValidator>();
           });
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                // Api'ye yap�lan isteklerde otomatik olarak ModelState'i kontrol edip hata al�nd���nda 400 yan�t�n� d�nmesini devre d��� b�rakt�k. Yukar�da uygulad���m�z validasyon filtresi ile art�k validasyon hatas� sonras�, 400 yan�t�n� validasyon filtremiz bizlere sa�lamaktad�r.
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
            // Projeye sonradan eklenmi� olan extend edilmi� dependency'leri belirtir.
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
