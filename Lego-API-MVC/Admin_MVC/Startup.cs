
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Roposityres.Repository;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER_API.Authontaction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Models.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Admin_MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddDbContextPool<legoContext>(opts =>
            //opts.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            #region Adding JWT Bearer
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //        .AddJwtBearer(options =>
            //         {
            //             options.SaveToken = true;
            //             options.RequireHttpsMetadata = false;
            //             options.TokenValidationParameters = new TokenValidationParameters()
            //             {
            //                 ValidateIssuer = true,
            //                 ValidateAudience = true,
            //                 //  ValidateLifetime = true,
            //                 //  ValidateIssuerSigningKey = true,
            //                 ValidAudience = Configuration["JWT:ValidAudience"],
            //                 ValidIssuer = Configuration["JWT:ValidIssuer"],
            //                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
            //             };
            //         }
            //    );

            #endregion Adding JWT Bearer
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("connStr"));
            });


            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 //.AddUserManager<ApplicationUser>()
                 //.AddSignInManager<ApplicationUser>()
                 //.AddDefaultTokenProviders();
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

            services.AddScoped(typeof(IModelRepository<>), typeof(ModelRepository<>));
            services.AddScoped(typeof(IRepositoryForMany<>), typeof(RepositoryForMany<>));
            services.AddScoped<IUnitOfWork, unitOfWork>();

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
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(env.ContentRootPath, "wwwroot/"))
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
