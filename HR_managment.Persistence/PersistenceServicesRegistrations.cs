
using HR_managment.Persistence.Repositories;
using HR_Managment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_managment.Persistence
{
    public static class PersistenceServicesRegistrations
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<LeaveManagmentDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagmentConnectionString"));
            });
            service.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            service.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
            service.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();
            service.AddScoped<ILeaveAllocationRepository,LeaveAllocationRepository>();
            return service;
        }
    }
}
