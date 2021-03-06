using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Entities;
using Library.Models;
using Library.Repositories;
using Library.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library
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
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            services.AddControllersWithViews();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IReaderService, ReaderService>();
            services.AddTransient<IAccountService, AuthorService>();
            services.AddSingleton(configuration.CreateMapper());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IReaderCardRepository, ReaderCardRepository>();
            services.AddScoped<IRecordRepository, RecordRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddDbContext<LibraryContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
