using JobCandidateHubAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Data.IRepositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetAsync(Expression<Func<Candidate, bool>> expression, bool isTracking = true);
        Task CreateAsync(Candidate entity);
        void Update(Candidate entity);
        Task SaveChangesAsync();
    }
}
