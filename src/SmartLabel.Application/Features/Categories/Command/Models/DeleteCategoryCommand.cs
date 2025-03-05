using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SmartLabel.Application.Features.Categories.Command.Models
{
	public class DeleteCategoryCommand : IRequest
	{
		public int Id { get; }
		public DeleteCategoryCommand(int id)
		{
			Id = id;
		}
	}
}
