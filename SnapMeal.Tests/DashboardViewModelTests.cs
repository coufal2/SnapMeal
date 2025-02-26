using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapMeal.App.ViewModels;
using Moq;
using System.Threading.Tasks;

namespace SnapMeal.Tests.ViewModels
{
    [TestClass]
    public class DashboardViewModelTests
    {
        [TestMethod]
        public async Task LoadRecipes_ShouldPopulateRecipeList()
        {
            var dashboardViewModel = new DashboardViewModel();
            await dashboardViewModel.LoadRecipes();

            Assert.IsTrue(dashboardViewModel.Recipes.Count > 0);
        }
    }
}
