using MediatR;
using SmartLabel.Application.Features.Categories.Query.Results;

namespace SmartLabel.Application.Features.Categories.Query.Models;
public class GetAllCategoryQuery : IRequest<IEnumerable<GetCategoryResult>>
{

}

