using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapMeal.API.Services;
using SnapMeal.API.Models;
using Moq;
using System.Threading.Tasks;

namespace SnapMeal.Tests.Services
{
	[TestClass]
	public class AuthServiceTests
	{
		[TestMethod]
		public async Task RegisterAsync_ShouldReturnSuccess_WhenUserIsValid()
		{
			var authServiceMock = new Mock<AuthService>(null);
			var user = new User { Email = "test@test.com", Password = "password123" };

			var result = await authServiceMock.Object.RegisterAsync(user);

			Assert.IsTrue(result.Success);
		}

		[TestMethod]
		public async Task LoginAsync_ShouldReturnToken_WhenCredentialsAreValid()
		{
			var authServiceMock = new Mock<AuthService>(null);
			var userLogin = new UserLogin { Email = "test@test.com", Password = "password123" };

			var result = await authServiceMock.Object.LoginAsync(userLogin);

			Assert.IsNotNull(result.Token);
		}
	}
}
