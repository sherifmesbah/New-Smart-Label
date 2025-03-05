using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SmartLabel.Application.Features.Categories.Query.Results;

namespace SmartLabel.Application.Features.Categories.Query.Models
{
	public class GetCategoryByIdQuery : IRequest<GetCategoryResult>
	{
		public int Id { get; set; }

		public GetCategoryByIdQuery(int id)
		{
			Id = id;
		}
	}
}
