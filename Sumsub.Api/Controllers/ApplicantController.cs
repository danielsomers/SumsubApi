

using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Sumsub.Api.Models;
using Sumsub.Api.Services;

namespace Sumsub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            this._applicantService = applicantService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Save([FromBody] WebhookPayload payload)
        {//todo add a logging service
            try
            {
                
                _applicantService.SaveApplicant(payload);
                Console.WriteLine($"Received webhook of type {payload.Type} for applicant {payload.ApplicantId}");

                return Created();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving an applicant for client with ID: {payload.ApplicantId}.");
                return StatusCode((int) HttpStatusCode.InternalServerError, "An error occurred while processing the request.");

            }
        }
    }
}