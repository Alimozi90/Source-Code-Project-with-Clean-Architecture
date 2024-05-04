using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Application.Contracts.Persistence.Orders;
using N_Shop.Application.Contracts.Persistence.Products;
using N_Shop.Application.Contracts.Persistence.Role_Permissions;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Persistence.Repositories.Common;
using N_Shop.Persistence.Repositories.Orders;
using N_Shop.Persistence.Repositories.Products;
using N_Shop.Persistence.Repositories.Role_Permissions;
using N_Shop.Persistence.Repositories.Users;

namespace N_Shop.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<N_ShopDbContext>(option =>
           {
               option.UseSqlServer(configuration.GetConnectionString("N_ShopConnetionString"));
           });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #region Orders 
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            #endregion

            #region Products 
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            services.AddScoped<IProductCommentVoteRepository, ProductCommentVoteRepository>();
            services.AddScoped<IProductVoteRepository, ProductVoteRepository>();
            #endregion

            #region Role_Permissions 
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            #endregion

            #region Users 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            #endregion
            return services;
        }
    }
}
