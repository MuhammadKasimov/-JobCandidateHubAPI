using FluentAssertions.Primitives;
using FluentAssertions;
using JobCandidateHubAPI.Data.Contexts;
using JobCandidateHubAPI.Data.IRepositories;
using JobCandidateHubAPI.Data.Repositories;
using JobCandidateHubAPI.Domain.Entities;
using JobCandidateHubAPI.Service.DTOs;
using JobCandidateHubAPI.Service.Interfaces;
using JobCandidateHubAPI.Service.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace JobCandidateHubAPI.UnitTest.Services
{
    public partial class CandidateServiceTests
    {
        private readonly AppDbContext appDbContext;
        private readonly ICandidateRepository candidateRepositoryMock;
        private readonly ICandidateService candidateServiceMock;
        public CandidateServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            appDbContext = new AppDbContext(options);
            candidateRepositoryMock = new CandidateRepository(appDbContext);
            candidateServiceMock = new CandidateService(candidateRepositoryMock);
        }

        private static CandidateForCreationDTO CreateRandomCandidate() 
        {
            CandidateForCreationDTO candidateForCreationDTO = new CandidateForCreationDTO();
            candidateForCreationDTO.FirstName = Faker.Name.First();
            candidateForCreationDTO.FirstName = Faker.Name.Last();
            candidateForCreationDTO.Email = Faker.Internet.Email();
            candidateForCreationDTO.PhoneNumber = Faker.Phone.Number();
            candidateForCreationDTO.GithubUrl = "https://github.com/RandomUser";
            candidateForCreationDTO.LinkedInUrl = "https://linkedin.com/in/RandomUser";
            candidateForCreationDTO.TimeForCall = DateTime.UtcNow;
            candidateForCreationDTO.Comment = Faker.Lorem.Sentence();

            return candidateForCreationDTO;
        }
    }
}
