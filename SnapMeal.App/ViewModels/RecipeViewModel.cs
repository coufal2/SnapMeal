using System.Windows.Input;

namespace SnapMeal.App.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        public Recipe Recipe { get; set; }

        public ICommand GoBackCommand { get; }

        public RecipeViewModel(Recipe recipe)
        {
            Recipe = recipe;
            GoBackCommand = new Command(GoBack);
        }

        private async void GoBack()
        {
            // Navigate back to the DashboardPage
            await Shell.Current.GoToAsync("..");
        }
    }
}
