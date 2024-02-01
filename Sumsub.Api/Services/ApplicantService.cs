using System;
using Sumsub.Api.Models;
using Sumsub.DataAccess;
using Sumsub.DataAccess.Models;
using ReviewResult = Sumsub.Api.Models.ReviewResult;

namespace Sumsub.Api.Services;

public class ApplicantService : IApplicantService
{
    private readonly ApplicationDbContext _context;

    public ApplicantService(ApplicationDbContext context)
    {
        _context = context;
    }
    public void SaveApplicant(WebhookPayload payload)
    {
        Console.WriteLine($"ApplicantId: {payload.ApplicantId}");
        Console.WriteLine($"InspectionId: {payload.InspectionId}");
        Console.WriteLine($"CorrelationId: {payload.CorrelationId}");
        Console.WriteLine($"LevelName: {payload.LevelName}");
        Console.WriteLine($"ExternalUserId: {payload.ExternalUserId}");
        Console.WriteLine($"Type: {payload.Type}");
        Console.WriteLine($"SandboxMode: {payload.SandboxMode}");
        Console.WriteLine($"ReviewStatus: {payload.ReviewStatus}");
        Console.WriteLine($"CreatedAtMs: {payload.CreatedAtMs}");
        Console.WriteLine($"ClientId: {payload.ClientId}");

        if (payload.ReviewResult != null)
        {
            Console.WriteLine($"ModerationComment: {payload.ReviewResult.ModerationComment}");
            Console.WriteLine($"ClientComment: {payload.ReviewResult.ClientComment}");
            Console.WriteLine($"ReviewAnswer: {payload.ReviewResult.ReviewAnswer}");

            if (payload.ReviewResult.RejectLabels != null)
            {
                foreach (string label in payload.ReviewResult.RejectLabels)
                {
                    Console.WriteLine($"RejectLabel: {label}");
                }
            }

            Console.WriteLine($"ReviewRejectType: {payload.ReviewResult.ReviewRejectType}");
        }

        if (payload.ReviewResult != null)
        {
            if (payload.ReviewResult.ReviewAnswer == "RED")
            {
                Console.WriteLine($"Review result for client {payload.ClientId} is read");
                // do logic too handle this
            }
            if (payload.ReviewResult.RejectLabels != null)
            {
                var applicant = new Applicant
                {
                    Id = Guid.NewGuid(),
                    InspectionId = Guid.Parse(payload.InspectionId),
                    CorrelationId = payload.CorrelationId,
                    LevelName = payload.LevelName,
                    ExternalUserId = long.Parse(payload.ExternalUserId),
                    Type = payload.Type,
                    SandboxMode = payload.SandboxMode,
                    ReviewStatus = payload.ReviewStatus,
                    CreatedAt = payload.CreatedAt,
                    CreatedAtMs = payload.CreatedAtMs,
                    ClientId = payload.ClientId,
                    ReviewResult = new DataAccess.Models.ReviewResult
                    {
                        ModerationComment = payload.ReviewResult.ModerationComment,
                        ClientComment = payload.ReviewResult.ClientComment,
                        ReviewAnswer = payload.ReviewResult.ReviewAnswer,
                        RejectLabels = payload.ReviewResult.RejectLabels,
                        ReviewRejectType = payload.ReviewResult.ReviewRejectType
                    }
                };

                _context.Applicants.Add(applicant);
            }
        }

        _context.SaveChanges();
    }
}