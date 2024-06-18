using JobCandidateHubAPI.Data.Contexts;
using JobCandidateHubAPI.Data.IRepositories;
using JobCandidateHubAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private AppDbContext dbContext { get; set; }
        private DbSet<Candidate> dbSet;
        public CandidateRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<Candidate>();
        }


        public async Task<Candidate> CreateAsync(Candidate entity)
            => (await dbSet.AddAsync(entity)).Entity;


        public Candidate Update(Candidate entity) =>
            dbSet.Update(entity).Entity;

        public IQueryable<Candidate> GetAll(Expression<Func<Candidate, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            IQueryable<Candidate> query = expression is null ? dbSet : dbSet.Where(expression);

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<Candidate> GetAsync(Expression<Func<Candidate, bool>> expression, bool isTracking = true, string[] includes = null) =>
            await GetAll(expression, includes, false).FirstOrDefaultAsync();
    }
}
