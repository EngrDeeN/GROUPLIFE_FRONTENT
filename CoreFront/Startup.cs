using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoreFront
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
            services.AddCors();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc(options =>
            {
                //any other settings
            })
                       .AddNewtonsoftJson(options =>
                       {
                           options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                       });

            services.AddCors(options =>
            {
                options.AddPolicy("GlobalWebPolicy",

                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });

                //builder =>
                //    {
                //        builder.WithOrigins("http://localhost:16948",
                //                            "http://localhost:16948",
                //                            "http://localhost")
                //                            .AllowAnyHeader()
                //                            .AllowAnyMethod();
                //    });
            });
            services.AddSession(options =>
            {
                options.Cookie.Name = "Session";
                options.IdleTimeout = TimeSpan.FromSeconds(50000);
                options.Cookie.IsEssential = true;
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
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Entities}/{action=SignIn}");
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "Customer",
                 pattern: "Customer/{controller=Customer}/{action=Customer}");
                endpoints.MapControllerRoute(
                 name: "Testing",
              pattern: "Testing/{controller=Customer}/{action=Testing}");

                endpoints.MapControllerRoute(
                    name: "Institution",
                 pattern: "Institution/{controller=Institution}/{action=Institution}");

                endpoints.MapControllerRoute(
                    name: "CustomerFileUpload",
                 pattern: "CustomerFileUpload/{controller=Entities}/{action=CustomerFileUpload}");

                endpoints.MapControllerRoute(
                    name: "ProductMaster",
                 pattern: "ProductMaster/{controller=ProductMaster}/{action=ProductMaster}");

                endpoints.MapControllerRoute(
                    name: "Quotation",
                 pattern: "Quotation/{controller=New_Business}/{action=Quotation}");

                endpoints.MapControllerRoute(
                   name: "QuotationProcess",
                pattern: "QuotationProcess/{controller=New_Business}/{action=QuotationProcess}");

                endpoints.MapControllerRoute(
                    name: "Duplic_Quotation",
                 pattern: "Duplic_Quotation/{controller=New_Business}/{action=Duplic_Quotation}");

                endpoints.MapControllerRoute(
                    name: "PolicyIssuance",
                 pattern: "PolicyIssuance/{controller=New_Business}/{action=PolicyIssuance}");

                endpoints.MapControllerRoute(
                    name: "Payment_Receipt",
                 pattern: "Payment_Receipt/{controller=Payment_Receipt}/{action=Payment_Receipt}");

                endpoints.MapControllerRoute(
                    name: "Report",
                 pattern: "Report/{controller=Entities}/{action=Report}");

                endpoints.MapControllerRoute(
                   name: "UnderWritingPersons",
                pattern: "UnderWritingPersons/{controller=Policy_UW}/{action=UnderWritingPersons}");

                endpoints.MapControllerRoute(
                   name: "IndivUnderWritting",
                pattern: "IndivUnderWritting/{controller=Policy_UW}/{action=IndivUnderWritting}");

                endpoints.MapControllerRoute(
                    name: "GL_IndivAddi",
                 pattern: "GL_IndivAddi/{controller=Policy_UW}/{action=GL_IndivAddi}");

                endpoints.MapControllerRoute(
                   name: "GL_IndivDele",
                pattern: "GL_IndivDele/{controller=Policy_UW}/{action=GL_IndivDele}");

                endpoints.MapControllerRoute(
                   name: "Agent_Registration",
                pattern: "Agent_Registration/{controller=Agent}/{action=Agent_Registration}");

                endpoints.MapControllerRoute(
                   name: "Policy_Claims",
                pattern: "Policy_Claims/{controller=Policy_Claims}/{action=Policy_Claims}");

                endpoints.MapControllerRoute(
                   name: "Inquiry",
                pattern: "Inquiry/{controller=Inquiry}/{action=Inquiry}");

            });
        }
    }
}
