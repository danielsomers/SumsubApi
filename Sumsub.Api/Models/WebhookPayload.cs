using System;

namespace Sumsub.Api.Models;

public class WebhookPayload
{
    public string ApplicantId { get; set; }
    public string InspectionId { get; set; }
    public string CorrelationId { get; set; }
    public string LevelName { get; set; }
    public string ExternalUserId { get; set; }
    public string Type { get; set; }
    public string SandboxMode { get; set; }
    public string ReviewStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime CreatedAtMs { get; set; }
    public string ClientId { get; set; }
    public ReviewResult ReviewResult { get; set; }
}