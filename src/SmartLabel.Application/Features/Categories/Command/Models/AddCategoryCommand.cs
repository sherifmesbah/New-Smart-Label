using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartLabel.Application.Features.Categories.Command.Results;

namespace SmartLabel.Application.Features.Categories.Command.Models
{
	public class AddCategoryCommand : IRequest<AddCategoryCommand>
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? ImageUrl { get; set; }
		public AddCategoryCommand(AddCategoryResult category, string imageUrl)
		{
			Id = category.Id;
			Name = category.Name;	
			ImageUrl = imageUrl;
		}
	}
}
