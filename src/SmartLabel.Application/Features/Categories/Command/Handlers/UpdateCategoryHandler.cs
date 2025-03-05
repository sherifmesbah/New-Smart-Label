using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartLabel.Application.Features.Categories.Command.Models;
using SmartLabel.Application.Features.Categories.Command.Results;
using SmartLabel.Domain.Entities;
using SmartLabel.Domain.Repositories;

namespace SmartLabel.Application.Features.Categories.Command.Handlers
{
	public class UpdateCategoryHandler(ICategoryRepository repository, IMapper mapper) : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommand>
	{
		public async Task<UpdateCategoryCommand> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = mapper.Map<Category>(request);
			await repository.UpdateCategory(category);
			request.Id = category.Id;
			return request;
		}
	}
}
