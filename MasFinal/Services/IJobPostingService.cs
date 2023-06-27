using MasFinal.Models;

namespace MasFinal.Services
{
    /// <summary>
    /// Interface for job posting-related operations.
    /// </summary>
    public interface IJobPostingService
    {
        /// <summary>
        /// Retrieves a list of job applicants for the specified job posting.
        /// </summary>
        /// <param name="jobPostingId">The ID of the job posting.</param>
        /// <returns>A list of job applicants for the specified job posting.</returns>
        List<JobApplication> GetApplicantsForJobPosting(int jobPostingId);
    }
}
