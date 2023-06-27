using MasFinal.Data;
using MasFinal.Enums;
using MasFinal.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace MasFinal.Services
{
    /// <summary>
    /// Service class for handling recruiter-related operations.
    /// </summary>
    public class RecruiterService : IRecruiterService
    {
        private readonly MasFinalContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecruiterService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public RecruiterService(MasFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves a list of job postings associated with the specified recruiter.
        /// </summary>
        /// <param name="recruiterId">The ID of the recruiter.</param>
        /// <returns>A list of job postings.</returns>
        public List<JobPosting> GetJobPostings(int recruiterId)
        {
            if (recruiterId <= 0)
            {
                return new List<JobPosting>();
            }
            else
                return _dbContext.JobPostings
                .Include(jp => jp.Company)
                .Where(jp => jp.RecruiterId == recruiterId)
                .ToList();
        }

        /// <summary>
        /// Accepts an applicant for a specific job posting.
        /// </summary>
        /// <param name="jobPostingId">The ID of the job posting.</param>
        /// <param name="applicationId">The ID of the application.</param>
        public void AcceptApplicant(int applicationId)
        {
            var application = _dbContext.JobApplications.FirstOrDefault(app => app.Id == applicationId);
            if (application == null)
            {
                // Application not found, handle accordingly (throw exception, return, etc.)
                return;
            }

            application.Status = StatusType.Accepted;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Rejects an applicant for a specific job posting.
        /// </summary>
        /// <param name="applicationId">The ID of the application.</param>
        public void RejectApplicant(int applicationId)
        {
            var application = _dbContext.JobApplications.FirstOrDefault(app => app.Id == applicationId);
            if (application == null)
            {
                // Application not found, handle accordingly (throw exception, return, etc.)
                return;
            }

            application.Status = StatusType.Rejected;
            _dbContext.SaveChanges();
        }
    }
}
