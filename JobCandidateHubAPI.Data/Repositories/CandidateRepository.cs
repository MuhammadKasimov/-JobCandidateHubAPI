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


        public async Task CreateAsync(Candidate entity)
            => await dbSet.AddAsync(entity);


        public void Update(Candidate entity) =>
            dbSet.Update(entity);

        public async Task<Candidate> GetAsync(Expression<Func<Candidate, bool>> expression, bool isTracking = true) =>
            await dbSet.Where(expression).FirstOrDefaultAsync();


        public async Task SaveChangesAsync() =>
            await dbContext.SaveChangesAsync();
    }
}
