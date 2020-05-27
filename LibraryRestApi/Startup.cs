using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryRestApi.BusinessLayer;
using LibraryRestApi.BusinessLayer.Services;
using LibraryRestApi.DataAccessLayer;
using LibraryRestApi.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryRestApi
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
            services.AddControllers();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IReaderService, ReaderService>();
            services.AddTransient<IAuthorService, AuthorService>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
