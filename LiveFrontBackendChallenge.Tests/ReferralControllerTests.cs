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
            var mockDeferredLinkService = new Mock<IDeferredLinkService>();
            var mockReferralService = new Mock<IReferralService>();
            ReferralController referralController = new(mockUserService.Object, mockDeferredLinkService.Object, mockReferralService.Object);
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
            var mockDeferredLinkService = new Mock<IDeferredLinkService>();
            var mockReferralService = new Mock<IReferralService>();
            ReferralController referralController = new(mockUserService.Object, mockDeferredLinkService.Object, mockReferralService.Object);
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
            var mockDeferredLinkService = new Mock<IDeferredLinkService>();
            var mockReferralService = new Mock<IReferralService>();
            mockReferralService.Setup(r => r.CreateReferral(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((int userId, string referralCode, string deferredLink) =>
                    {
                        return Task.FromResult(
                            new ReferralDto
                            {
                                UserId = userId,
                                ReferralCode = referralCode,
                                DeferredLink = deferredLink,
                                Activated = false,
                                ReferralId = 1
                            }
                        );
                    }
                );
            ReferralController referralController = new(mockUserService.Object, mockDeferredLinkService.Object, mockReferralService.Object);
            // When
            var response = await referralController.CreateReferral(createReferralRequest);
            var responseObject = response as ObjectResult;
            // Then
            responseObject.Should().NotBeNull();
            responseObject?.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void ReferralController_Creates_DeferredLink_With_ReferralCode()
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
            var mockDeferredLinkService = new Mock<IDeferredLinkService>();
            mockDeferredLinkService.Setup(d => d.GetDeferredLink(It.IsAny<string>())).Returns(Task.FromResult($"test.url.with/referralcode?referralCode={createReferralRequest.ReferralCode}"));
            var mockReferralService = new Mock<IReferralService>();
            mockReferralService.Setup(r => r.CreateReferral(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((int userId, string referralCode, string deferredLink) =>
                    {
                        return Task.FromResult(
                            new ReferralDto
                            {
                                UserId = userId,
                                ReferralCode = referralCode,
                                DeferredLink = deferredLink,
                                Activated = false,
                                ReferralId = 1
                            }
                        );
                    }
                );
            ReferralController referralController = new(mockUserService.Object, mockDeferredLinkService.Object, mockReferralService.Object);
            // When
            var response = await referralController.CreateReferral(createReferralRequest);
            var responseObject = response as ObjectResult;
            // Then
            responseObject.Should().NotBeNull();
            responseObject?.StatusCode.Should().Be(200);
            var responseValue = responseObject?.Value as ReferralDto;
            responseValue?.DeferredLink.Should().Contain(createReferralRequest.ReferralCode);
        }
        
    }
}