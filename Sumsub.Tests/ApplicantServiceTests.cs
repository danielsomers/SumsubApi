using Microsoft.EntityFrameworkCore;
using Moq;
using Sumsub.Api.Models;
using Sumsub.Api.Services;
using Sumsub.DataAccess;
using Sumsub.DataAccess.Models;
using ReviewResult = Sumsub.Api.Models.ReviewResult;

namespace Sumsub.Tests;

public class ApplicantServiceTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly ApplicantService _service;

    public ApplicantServiceTests()
    {
        _mockContext = new Mock<ApplicationDbContext>();
        _service = new ApplicantService(_mockContext.Object);
    }
    
    [Fact]
    public void SaveApplicant_WithValidPayload_AddsApplicantToContextWithCorrectValues()
    {
        // Arrange
        var webhookPayload = new WebhookPayload 
        { 
            ApplicantId = "test",
            InspectionId = Guid.NewGuid().ToString(),
            // Continue initializing the rest of the webhookPayload properties...
        };

        // Act
        _service.SaveApplicant(webhookPayload);

        // Assert
        _mockContext.Verify(
            context => context.Applicants.Add(
                It.Is<Applicant>(
                    a => a.InspectionId == Guid.Parse(webhookPayload.InspectionId)
                )
            ),
            Times.Once
        );

        _mockContext.Verify(context => context.SaveChanges(), Times.Once);
    }
    [Fact]
    public async Task yload_AddsApplicantToContextWithCorrectValues2()
    {
        // Arrange
    
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var webhookPayload = new WebhookPayload 
        { 
            ApplicantId = "test",
            InspectionId = Guid.NewGuid().ToString(),
            ReviewResult = new ReviewResult()
            {
                ModerationComment = "test",
                ClientComment = "test",
                ReviewAnswer = "test",
                RejectLabels = new List<string> { "label1", "label2" },
                ReviewRejectType = "test"
            }
            // Continue initializing the rest of the webhookPayload properties...
        };

        using (var context = new ApplicationDbContext(options))
        {
            // Arrange


            // Act
            _service.SaveApplicant(webhookPayload);
            
            // Assert
            Assert.Equal(1, context.Applicants.Count());
            //Assert.Equal(availableSlots.First().StartTime,
            //    context.Availabilities.First().TimeSlots.First().StartTime);
        }
    }
}