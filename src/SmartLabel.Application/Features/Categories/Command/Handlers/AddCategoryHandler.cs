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

namespace SmartLabel.Application.Features.Categories.Command.Handlers;
public class AddCategoryHandler(IMapper mapper, ICategoryRepository repository) :
	IRequestHandler<AddCategoryCommand, AddCategoryCommand>
{
	public async Task<AddCategoryCommand> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = mapper.Map<Category>(request);
		await repository.AddCategory(category);
		request.Id = category.Id;
		return request;
	}
}