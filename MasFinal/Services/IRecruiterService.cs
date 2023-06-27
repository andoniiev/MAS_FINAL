using MasFinal.Models;
using System.Collections.Generic;

namespace MasFinal.Services
{
    /// <summary>
    /// Interface for recruiter-related operations.
    /// </summary>
    public interface IRecruiterService
    {
        /// <summary>
        /// Retrieves the job postings associated with the specified recruiter.
        /// </summary>
        /// <param name="recruiterId">The ID of the recruiter.</param>
        /// <returns>A list of job postings associated with the recruiter.</returns>
        List<JobPosting> GetJobPostings(int recruiterId);

        /// <summary>
        /// Accepts an applicant for a specific job posting.
        /// </summary>
        /// <param name="jobPostingId">The ID of the job posting.</param>
        /// <param name="applicationId">The ID of the application to accept.</param>
        void AcceptApplicant(int applicationId);

        /// <summary>
        /// Rejects an applicant by their application ID.
        /// </summary>
        /// <param name="applicationId">The ID of the application to reject.</param>
        void RejectApplicant(int applicationId);
    }
}
