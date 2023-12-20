using App.AppService;
using App.AppService._Base;
using App.Interfaces;
using App.Interfaces._Base;
using Data.Context;
using Data.Context.Interfaces;
using Data.Repositories;
using Data.Repositories._Base;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository._Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services._Base;
using Domain.Services;
using Domain.Services._Base;

namespace AppWebApi.ServicesCollection
{
    public static class ServicesCollection
    {
        public static void AddVendaProdutoContext(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDbContext), typeof(DBContext));
        }

        public static void AddVendaProdutoServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppService<>), typeof(AppService<>));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            #region App
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<ISupplierAppService, SupplierAppService>();
            services.AddScoped<IProductSupplierAppService, ProductSupplierAppService>();
            #endregion

            #region Domain
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductSupplierService, ProductSupplierService>();
            #endregion

            #region Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProductSupplierRepository, ProductSupplierRepository>();
            #endregion
        }
    }
}
