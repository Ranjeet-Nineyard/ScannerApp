using Scanner.Data.Interface;
using Scanner.Data;

namespace Scanner.API.DI
{
    public  class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICommonData, CommonData>();
        }
    }
}
