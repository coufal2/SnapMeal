using SnapMeal.API.Data;
using SnapMeal.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnapMeal.API.Services
{
	public interface IRecipeService
	{
		Task<List<Recipe>> GetAllRecipesAsync();
		Task<Recipe> GetRecipeByIdAsync(int id);
		Task AddRecipeAsync(Recipe recipe);
		Task<bool> UpdateRecipeAsync(int id, Recipe recipe);
		Task<bool> DeleteRecipeAsync(int id);
	}

	public class RecipeService : IRecipeService
	{
		private readonly AppDbContext _dbContext;

		public RecipeService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Recipe>> GetAllRecipesAsync()
		{
			return await _dbContext.Recipes.ToListAsync();
		}

		public async Task<Recipe> GetRecipeByIdAsync(int id)
		{
			return await _dbContext.Recipes.FindAsync(id);
		}

		public async Task AddRecipeAsync(Recipe recipe)
		{
			await _dbContext.Recipes.AddAsync(recipe);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> UpdateRecipeAsync(int id, Recipe recipe)
		{
			var existingRecipe = await _dbContext.Recipes.FindAsync(id);
			if (existingRecipe == null) return false;

			existingRecipe.Name = recipe.Name;
			existingRecipe.Ingredients = recipe.Ingredients;
			existingRecipe.Instructions = recipe.Instructions;
			existingRecipe.ImageUrl = recipe.ImageUrl;

			_dbContext.Recipes.Update(existingRecipe);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteRecipeAsync(int id)
		{
			var recipe = await _dbContext.Recipes.FindAsync(id);
			if (recipe == null) return false;

			_dbContext.Recipes.Remove(recipe);
			await _dbContext.SaveChangesAsync();
			return true;
		}
	}
}
