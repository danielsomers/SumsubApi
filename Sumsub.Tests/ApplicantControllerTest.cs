using System.Net;
using Xunit;
using Sumsub.Api.Controllers;
using Sumsub.Api.Services;
using Sumsub.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sumsub.Api.Models;

namespace Sumsub.Tests
{
    public class ApplicantControllerTest
    {
        private readonly Mock<IApplicantService> _mockApplicantService;
        private readonly ApplicantController _controller;
        
        public ApplicantControllerTest()
        {
            _mockApplicantService = new Mock<IApplicantService>();
            _controller = new ApplicantController(_mockApplicantService.Object);
        }
        
        [Fact]
        public void Should_Call_SaveApplicant_When_Payload_Is_Valid()
        {
            // Arrange
            WebhookPayload payload = new WebhookPayload 
            {
                Type = "Expected Type", // change it with your actual expected type
                ApplicantId = "Expected Applicant Id" // change it with your actual expected applicant id
            };

            // Act
            var result = _controller.Save(payload);

            // Assert
            _mockApplicantService.Verify(s => s.SaveApplicant(payload), Times.Once);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Should_Return_InternalServerError_On_Exception()
        {
            // Arrange
            WebhookPayload payload = new WebhookPayload 
            {
                Type = "Expected Type", // change it with your actual expected type
                ApplicantId = "Expected Applicant Id" // change it with your actual expected applicant id
            };

            _mockApplicantService
                .Setup(a => a.SaveApplicant(payload))
                .Throws(new Exception());
                
            // Act
            var result = _controller.Save(payload);

            // Assert
            _mockApplicantService.Verify(s => s.SaveApplicant(payload), Times.Once);
            Assert.IsType<ObjectResult>(result); // StatusCode((int)HttpStatusCode.InternalServerError, "...") returns ObjectResult
            var objectResult = result as ObjectResult;
            Assert.Equal((int) HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }
    }
}