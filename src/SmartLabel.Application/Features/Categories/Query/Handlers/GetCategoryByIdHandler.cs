using AutoMapper;
using MediatR;
using SmartLabel.Application.Features.Categories.Query.Models;
using SmartLabel.Application.Features.Categories.Query.Results;
using SmartLabel.Domain.Repositories;

namespace SmartLabel.Application.Features.Categories.Query.Handlers
{
	public class GetCategoryByIdHandler(ICategoryRepository repository, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, GetCategoryResult>
	{
		public async Task<GetCategoryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			var category = mapper.Map<GetCategoryResult>(await repository.GetCategoryById(request.Id));
			return category;
		}
	}
}
