using SnapMeal.API.Services;
using SnapMeal.API.Models;
using Moq;
using Xunit;
using System.Threading.Tasks;

public class RecipeServiceTests
{
    private readonly IRecipeService _recipeService;

    public RecipeServiceTests()
    {
        var mockDbContext = new Mock<AppDbContext>();
        _recipeService = new RecipeService(mockDbContext.Object);
    }

    [Fact]
    public async Task GetAllRecipes_ReturnsRecipes()
    {
        var recipes = await _recipeService.GetAllRecipesAsync();
        Assert.NotNull(recipes);
    }

    [Fact]
    public async Task AddRecipe_AddsNewRecipe()
    {
        var recipe = new Recipe { Name = "Test Recipe" };
        await _recipeService.AddRecipeAsync(recipe);
        var result = await _recipeService.GetRecipeByIdAsync(recipe.Id);
        Assert.NotNull(result);
    }
}
