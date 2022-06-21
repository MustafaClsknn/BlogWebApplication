using BlogWebApplication.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogWebApplicationEntities.Concrete;
using BlogWebApplication.DataAccess.Abstract;
using BlogWebApplication.DataAccess.Concrete.EntityFramework;
using BlogWebApplication.Business.Concrete;
using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Business.MapperProfile;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BlogWebApplication.Web
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

            services.AddControllersWithViews();

            services.AddScoped<IWriterRepository, EFWriterRepository>();
            services.AddScoped<IBlogRepository, EFBlogRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<ICommentRepository, EFCommentRepository>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IContactRepository, EFContactRepository>();

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IWriterService, WriterService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();

            var connectionString = Configuration.GetConnectionString("db");    
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MapProfile));
            services.AddSession();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/User/Login";
                        options.AccessDeniedPath = "/User/AccessDenied";
                    });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
