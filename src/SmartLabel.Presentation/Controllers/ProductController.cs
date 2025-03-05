using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLabel.Application.Features.Categories.Command.Models;
using SmartLabel.Application.Features.Categories.Command.Results;
using SmartLabel.Application.Features.Categories.Query.Models;
using SmartLabel.Presentation.Services;

namespace SmartLabel.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(IMediator mediator, IFileService fileService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllCategory()
		{
			var allCategories = await mediator.Send(new GetAllCategoryQuery());
			return Ok(allCategories);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(int id)
		{
			var res = await mediator.Send(new GetCategoryByIdQuery(id));
			return Ok(res);	
		}

		[HttpPost]
		public async Task<IActionResult> AddCategory([FromForm] AddCategoryResult category)
		{
			string imageUrl = await fileService.BuildImage(category.Image);
			var categoryResult = await mediator.Send(new AddCategoryCommand(category, imageUrl));
			return CreatedAtAction(nameof(GetCategoryById), new { id = categoryResult.Id }, categoryResult);
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryResult category)
		{
			var cat = await mediator.Send(new GetCategoryByIdQuery(category.Id));
			fileService.DeleteImage(cat.ImageUrl);
			string imageUrl = await fileService.BuildImage(category.Image);
			var categoryResult = await mediator.Send(new UpdateCategoryCommand(category, imageUrl));
			return Ok(categoryResult);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var cat = await mediator.Send(new GetCategoryByIdQuery(id));
			fileService.DeleteImage(cat.ImageUrl);
			await mediator.Send(new DeleteCategoryCommand(id));
			return NoContent();
		}
	}
}
