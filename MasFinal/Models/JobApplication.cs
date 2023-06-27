using MasFinal.Enums;

namespace MasFinal.Models
{
    /// <summary>
    /// Represents a job application.
    /// </summary>
    public class JobApplication
    {
        /// <summary>
        /// Gets or sets the ID of the job application.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date when the job application was submitted.
        /// </summary>
        public DateTime ApplicationDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the job application.
        /// </summary>
        public StatusType Status { get; set; } = default!;

        /// <summary>
        /// Gets or sets any comments or notes related to the job application.
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// Gets or sets the ID of the applicant associated with the job application.
        /// </summary>
        public int ApplicantId { get; set; }

        /// <summary>
        /// Gets or sets the employee who is the applicant of the job application.
        /// </summary>
        public Employee Applicant { get; set; } = default!;

        /// <summary>
        /// Gets or sets the ID of the job posting the application is for.
        /// </summary>
        public int JobPostingId { get; set; }

        /// <summary>
        /// Gets or sets the job posting the application is for.
        /// </summary>
        public JobPosting JobPosting { get; set; } = default!;
    }
}
