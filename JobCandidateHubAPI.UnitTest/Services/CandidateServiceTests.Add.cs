
using FluentAssertions;
using JobCandidateHubAPI.UnitTest.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.UnitTest.Services
{
    public partial class CandidateServiceTests
    {
        [Fact]
        public async Task ShouldAddCandidateAsync()
        {
            var randomCandidate = CreateRandomCandidate();
            await candidateServiceMock.CreateAsync(randomCandidate);

            randomCandidate.Should().BeValidForProperty("PhoneNumber");
            randomCandidate.Should().BeValidForProperty("Email");
            randomCandidate.Should().BeValidForProperty("LinkedInUrl");
            randomCandidate.Should().BeValidForProperty("GithubUrl");

            var createdCandidate = await candidateServiceMock.GetAsync(randomCandidate.Email);

            createdCandidate.Should().NotBeNull();
        }
    }
}
