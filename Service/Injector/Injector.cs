using Core.Service;
using Domain.Interface.RepositoryInterface;
using Domain.Interface.ServiceInterface;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
namespace Core.Injector
{
    public static class Injector
    {
        public static void Register(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterRepositories(services);
        }
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IProfessionalService, ProfessionalService>();
            services.AddScoped<IProjectTasksService, ProjectTasksService>();
            services.AddScoped<IFieldOfOperationService, FieldOfOperationService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            services.AddScoped<IProjectTasksRepository, ProjectTasksRepository>();
            services.AddScoped<IFieldOfOperationRepository, FieldOfOperationRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}