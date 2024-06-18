using JobCandidateHubAPI.Domain.Entities;
using JobCandidateHubAPI.Service.DTOs;
using JobCandidateHubAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Controllers
{
    [ApiController, Route("api/candidates")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService candidateService;
        public CandidatesController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        [HttpPost("create")]
        public async Task CreateAsync(CandidateForCreationDTO dto) =>
            await candidateService.CreateAsync(dto);

        [HttpGet("{email}")]
        public async Task<IActionResult> GetAsync(string email) => 
            Ok(await candidateService.GetAsync(email));
    }
}
