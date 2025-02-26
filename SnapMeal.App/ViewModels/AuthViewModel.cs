using System.Threading.Tasks;
using System.Windows.Input;
using SnapMeal.API.Services;
using SnapMeal.API.Models;
using Xamarin.Forms;

namespace SnapMeal.App.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public AuthViewModel(IAuthService authService)
        {
            _authService = authService;
            LoginCommand = new Command(async () => await OnLogin());
            RegisterCommand = new Command(async () => await OnRegister());
        }

        // Method to handle user login
        private async Task OnLogin()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email and Password cannot be empty.", "OK");
                return;
            }

            var userLogin = new UserLogin
            {
                Email = Email,
                Password = Password
            };

            var isAuthenticated = await _authService.LoginAsync(userLogin);

            if (isAuthenticated)
            {
                // Navigate to the dashboard page after successful login
                await App.Current.MainPage.Navigation.PushAsync(new DashboardPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid email or password.", "OK");
            }
        }

        // Method to handle user registration
        private async Task OnRegister()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email and Password cannot be empty.", "OK");
                return;
            }

            var newUser = new User
            {
                Email = Email,
                Password = Password
            };

            var isRegistered = await _authService.RegisterAsync(newUser);

            if (isRegistered)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Registration successful!", "OK");
                // Optionally navigate to login or another page after successful registration
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Registration failed.", "OK");
            }
        }
    }
}
