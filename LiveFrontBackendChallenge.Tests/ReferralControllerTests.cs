using FluentAssertions;
using LiveFrontBackendChallenge.Controllers;
using LiveFrontBackendChallenge.Models;
using LiveFrontBackendChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LiveFrontBackendChallenge.Tests
{
    public class ReferralControllerTests
    {
        [Fact]
        public async void ReferralController_ReturnsNotFound_If_UserDoesNotExist()
        {
            // Given
            CreateReferralRequest createReferralRequest = new()
            {
                UserId = 5,
                ReferralCode = "555555"
            };
            var mockUserService = new Mock<IUserService>();
            // mockUserService.Setup(u => u.GetUser(It.IsAny<int>())).Returns<User?>(null);
            ReferralController referralController = new(mockUserService.Object);
            // When
            var response = await referralController.CreateReferral(createReferralRequest);
            var responseObject = response as ObjectResult;
            // Then
            responseObject.Should().NotBeNull();
            responseObject?.StatusCode.Should().Be(404);
        }
        [Fact]
        public async void ReferralController_ReturnsBadRequest_If_ReferralCode_IsIncorrect()
        {
            // Given
            CreateReferralRequest createReferralRequest = new()
            {
                UserId = 1,
                ReferralCode = "222222"
            };
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(u => u.GetUser(It.IsAny<int>())).Returns(Task.FromResult(new User {
                UserId = 1,
                ReferralCode = "111111"
            }) as Task<User?>);
            ReferralController referralController = new(mockUserService.Object);
            // When
            var response = await referralController.CreateReferral(createReferralRequest);
            var responseObject = response as ObjectResult;
            // Then
            responseObject.Should().NotBeNull();
            responseObject?.StatusCode.Should().Be(400);
        }

        [Fact]
        public async void ReferralController_ReturnsOk_If_Valid_UserId_And_ReferralCode()
        {
            // Given
            CreateReferralRequest createReferralRequest = new()
            {
                UserId = 1,
                ReferralCode = "111111"
            };
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(u => u.GetUser(It.IsAny<int>())).Returns(Task.FromResult(new User {
                UserId = 1,
                ReferralCode = "111111"
            }) as Task<User?>);
            ReferralController referralController = new(mockUserService.Object);
            // When
            var response = await referralController.CreateReferral(createReferralRequest);
            var responseObject = response as ObjectResult;
            // Then
            responseObject.Should().NotBeNull();
            responseObject?.StatusCode.Should().Be(200);
        }
        
    }
}