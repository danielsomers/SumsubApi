namespace Sumsub.DataAccess.Models;

public class Applicant
{
    public Guid Id { get; set; }
    public Guid InspectionId { get; set; }
    public string CorrelationId { get; set; }
    public string LevelName { get; set; }
    public long ExternalUserId { get; set; }
    public string Type { get; set; }
    public string SandboxMode { get; set; }
    public string ReviewStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime CreatedAtMs { get; set; }
    public string ClientId { get; set; }
    public ReviewResult ReviewResult { get; set; }
}