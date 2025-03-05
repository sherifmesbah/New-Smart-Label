using MediatR;
using SmartLabel.Application.Features.Categories.Command.Results;

namespace SmartLabel.Application.Features.Categories.Command.Models;
public class UpdateCategoryCommand : IRequest<UpdateCategoryCommand>
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string? ImageUrl { get; set; }
	public UpdateCategoryCommand(UpdateCategoryResult category, string imageUrl)
	{
		Id = category.Id;
		Name = category.Name;
		ImageUrl = imageUrl;
	}
}