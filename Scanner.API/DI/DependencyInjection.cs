using Scanner.Data.Interface;
using Scanner.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Scanner.API.DI
{
    public  class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<ICommonData, CommonData>();
        }
    }
}
