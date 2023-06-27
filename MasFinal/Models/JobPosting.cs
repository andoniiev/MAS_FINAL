namespace MasFinal.Models
{
    /// <summary>
    /// Represents a job posting.
    /// </summary>
    public class JobPosting
    {
        /// <summary>
        /// Gets or sets the ID of the job posting.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the job posting.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the job posting.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of required skills for the job posting.
        /// </summary>
        public ICollection<Skill>? RequiredSkills { get; set; } = new List<Skill>();

        /// <summary>
        /// Gets or sets the maximum number of days the job posting can be active.
        /// </summary>
        public static int MaxDaysPosted { get; set; } = 60;

        /// <summary>
        /// Gets or sets the ID of the recruiter associated with the job posting.
        /// </summary>
        public int RecruiterId { get; set; }

        /// <summary>
        /// Gets or sets the recruiter associated with the job posting.
        /// </summary>
        public Recruiter Recruiter { get; set; } = default!;

        /// <summary>
        /// Gets or sets the list of job applications submitted for the job posting.
        /// </summary>
        public List<JobApplication>? JobApplications { get; set; } = new List<JobApplication>();

        /// <summary>
        /// Gets or sets the ID of the company associated with the job posting.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company associated with the job posting.
        /// </summary>
        public Company Company { get; set; } = default!;

        /// <summary>
        /// Gets or sets the date when the job posting was posted.
        /// </summary>
        public DateTime DatePosted { get; set; }
    }
}
