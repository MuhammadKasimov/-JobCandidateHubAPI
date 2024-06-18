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
        Task<Candidate> GetAsync(Expression<Func<Candidate, bool>> expression, bool isTracking = true, string[] includes = null);
        IQueryable<Candidate> GetAll(Expression<Func<Candidate, bool>> expression = null, string[] includes = null, bool isTracking = true);
        Task<Candidate> CreateAsync(Candidate entity);
        Candidate Update(Candidate entity);
    }
}
