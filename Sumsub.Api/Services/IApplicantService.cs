using Sumsub.Api.Models;

namespace Sumsub.Api.Services;

public interface IApplicantService
{
    void SaveApplicant(WebhookPayload payload);
}