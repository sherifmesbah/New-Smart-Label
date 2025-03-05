﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLabel.Domain.Repositories;
using SmartLabel.Infrastructure.Persistence.Data;
using SmartLabel.Infrastructure.Persistence.Repositories;

namespace SmartLabel.Infrastructure
{
	public static class InfrastructureModuleDependencies
	{
		public static IServiceCollection AddInfrastructures(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			return services;
		}
	}
}
