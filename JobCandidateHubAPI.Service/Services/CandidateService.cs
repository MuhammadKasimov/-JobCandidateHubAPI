using JobCandidateHubAPI.Data.IRepositories;
using JobCandidateHubAPI.Domain.Entities;
using JobCandidateHubAPI.Service.DTOs;
using JobCandidateHubAPI.Service.Exceptions;
using JobCandidateHubAPI.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Service.Services
{
    public class CandidateService : ICandidateService
    {
        private ICandidateRepository candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }
        public async Task CreateAsync(CandidateForCreationDTO dto)
        {
            var existUser = await candidateRepository.GetAsync(u => u.Email == dto.Email);

            if (existUser is not null)
            {
                dto.Adapt(existUser);
                existUser.UpdatedAt = DateTime.UtcNow;
                candidateRepository.Update(existUser);
                await candidateRepository.SaveChangesAsync();
                return;
            }
            await candidateRepository.CreateAsync(dto.Adapt<Candidate>());
            await candidateRepository.SaveChangesAsync();
        }

        public async Task<CandidateForViewDTO> GetAsync(string email)
        {
            var existUser = await candidateRepository.GetAsync(u => u.Email == email);
            if (existUser is null)
                throw new HttpStatusCodeException(404, "Candidate with such email not found");
            
            return existUser.Adapt<CandidateForViewDTO>();
        }
    }
}
