using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryManagement.Interfaces.Repository;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagementDATA.DataContect;
using LibraryManagementDATA.Repository;
using LibraryManagementDATA.Implementations;
using System;

namespace LibraryManagementCrossCutting.DependencyInjetction
{
    public class ConfigureRepository
    {
        public static void ConfDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<Guid, BaseEntity<Guid>>), typeof(BaseRepository<Guid, BaseEntity<Guid>>));
            serviceCollection.AddScoped<IAuthorRepository, AuthorImplementatios>();

            serviceCollection.AddDbContext<LibraryManagementContext>(
                options => options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=LibraryManagement;Trusted_Connection=True;MultipleActiveResultSets=true")
            );
        }
    }
}
