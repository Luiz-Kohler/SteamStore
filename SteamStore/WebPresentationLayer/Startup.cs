using BussinessLogicalLayer.IServices;
using BussinessLogicalLayer.Services;
using DataAccessLayer.SteamStore;
using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using DataAccessLayer.SteamStore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebPresentationLayer
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

            services.AddDbContextPool<SteamStoreContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SteamStore;Integrated Security=True"));


            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddTransient<IAdminService, AdminService>();

            services.AddScoped<IAdRepository, AdRepository>();
            services.AddTransient<IAdService, AdService>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddTransient<IItemService, ItemService>();

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddTransient<ISaleService, SaleService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<IFriendRepository, FriendRepository>();
            //services.AddTransient<IFriendService, FriendService>();

            services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
            //services.AddTransient<IFriendRequestService, FriendRequestService>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            //services.AddTransient<ICommentService, CommentService>();


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
