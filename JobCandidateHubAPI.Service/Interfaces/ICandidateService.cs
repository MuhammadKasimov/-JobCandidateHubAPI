using JobCandidateHubAPI.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Service.Interfaces
{
    public interface ICandidateService
    {
        Task CreateAsync(CandidateForCreationDTO userDto);
        Task<CandidateForViewDTO> GetAsync(string email);
    }
}
