using AutoMapper;
using MediatR;
using SmartLabel.Application.Features.Categories.Query.Models;
using SmartLabel.Application.Features.Categories.Query.Results;
using SmartLabel.Domain.Repositories;

namespace SmartLabel.Application.Features.Categories.Query.Handlers;
public class GetAllCategoryHandler(IMapper mapper, ICategoryRepository repository) : 
	IRequestHandler<GetAllCategoryQuery, IEnumerable<GetCategoryResult>>
{
	public async Task<IEnumerable<GetCategoryResult>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
	{
		var categories = mapper.Map<IEnumerable<GetCategoryResult>>(await repository.GetAllCategory());
		return categories;
	}
}

