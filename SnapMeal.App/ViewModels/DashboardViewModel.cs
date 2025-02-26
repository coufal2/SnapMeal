using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SnapMeal.App.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }

        public ICommand ViewRecipeCommand { get; }
        public ICommand AddRecipeCommand { get; }

        public DashboardViewModel()
        {
            Recipes = new ObservableCollection<Recipe>
            {
                new Recipe { Title = "Spaghetti", ImageUrl = "spaghetti.jpg", Ingredients = "Pasta, Tomato Sauce", Instructions = "Cook pasta, add sauce" },
                new Recipe { Title = "Salad", ImageUrl = "salad.jpg", Ingredients = "Lettuce, Tomato", Instructions = "Mix ingredients" }
            };

            ViewRecipeCommand = new Command<Recipe>(ViewRecipe);
            AddRecipeCommand = new Command(AddRecipe);
        }

        private void ViewRecipe(Recipe recipe)
        {
            // Navigate to RecipeDetailPage with selected recipe
        }

        private void AddRecipe()
        {
            // Navigate to AddRecipePage
        }
    }
}
