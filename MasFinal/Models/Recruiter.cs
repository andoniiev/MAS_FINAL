using MasFinal.Enums;

namespace MasFinal.Models
{
    /// <summary>
    /// Represents a recruiter.
    /// </summary>
    public class Recruiter : Person
    {
        /// <summary>
        /// Gets or sets the contact email of the recruiter.
        /// </summary>
        public string ContactEmail { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the contact phone number of the recruiter.
        /// </summary>
        public string ContactPhone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the owned company by the recruiter.
        /// </summary>
        public int? OwnedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the owned company by the recruiter.
        /// </summary>
        public Company? OwnedCompany { get; set; }

        /// <summary>
        /// Gets or sets the ID of the current company where the recruiter is employed.
        /// </summary>
        public int CurrentCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the current company where the recruiter is employed.
        /// </summary>
        public Company CurrentCompany { get; set; } = default!;

        /// <summary>
        /// Gets or sets the job postings created by the recruiter.
        /// </summary>
        public ICollection<JobPosting>? JobPostings { get; set; } = new List<JobPosting>();

        /// <summary>
        /// Gets or sets the type of the recruiter.
        /// </summary>
        public RecruiterType RecruiterType { get; set; } = default!;
    }
}
