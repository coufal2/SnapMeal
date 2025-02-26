using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapMeal.App.ViewModels;
using Moq;
using System.Threading.Tasks;

namespace SnapMeal.Tests.ViewModels
{
    [TestClass]
    public class RecipeViewModelTests
    {
        [TestMethod]
        public async Task AddRecipe_ShouldAddRecipeToList()
        {
            var recipeViewModel = new RecipeViewModel();
            await recipeViewModel.AddRecipe(new Recipe { Name = "Test Recipe" });

            Assert.IsTrue(recipeViewModel.Recipes.Count > 0);
        }
    }
}
