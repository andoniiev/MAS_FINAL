using MasFinal.Data;
using MasFinal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MasFinal.Services
{
    /// <summary>
    /// Service class for managing job postings.
    /// </summary>
    public class JobPostingService : IJobPostingService
    {
        private readonly MasFinalContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobPostingService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public JobPostingService(MasFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves the applicants for a specific job posting.
        /// </summary>
        /// <param name="jobPostingId">The ID of the job posting.</param>
        /// <returns>A list of job applications for the specified job posting.</returns>
        public List<JobApplication> GetApplicantsForJobPosting(int jobPostingId)
        {
            if (jobPostingId <= 0)
            {
                return new List<JobApplication>(); 
            }
            else
                return _dbContext.JobApplications
                    .Where(app => app.JobPostingId == jobPostingId)
                    .Include(app => app.Applicant)
                    .ThenInclude(app => app.Educations)
                    .Include(app => app.Applicant)
                    .ThenInclude(app => app.SkillList)
                    .ToList();
        }
    }
}
