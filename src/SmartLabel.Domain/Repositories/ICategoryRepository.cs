using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLabel.Domain.Entities;

namespace SmartLabel.Domain.Repositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category?>> GetAllCategory();
		Task<Category?> GetCategoryById(int id);
		Task AddCategory(Category category);
		Task<Category> UpdateCategory(Category category);
		Task DeleteCategory(Category category);
		Task<bool> IsExistCategory(int id);
	}
}
