using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SmartLabel.Application.Features.Categories.Command.Models;
using SmartLabel.Domain.Repositories;

namespace SmartLabel.Application.Features.Categories.Command.Handlers
{
	public class DeleteCategoryHandler(ICategoryRepository repository) : IRequestHandler<DeleteCategoryCommand>
	{
		public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await repository.GetCategoryById(request.Id);
			await repository.DeleteCategory(category);
		}
	}
}
