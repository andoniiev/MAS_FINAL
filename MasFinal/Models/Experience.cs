namespace MasFinal.Models
{
    /// <summary>
    /// Represents work experience.
    /// </summary>
    public class Experience
    {
        /// <summary>
        /// Gets or sets the ID of the experience.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company associated with the experience.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company associated with the experience.
        /// </summary>
        public Company Company { get; set; } = default!;

        /// <summary>
        /// Gets or sets the ID of the employee associated with the experience.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee associated with the experience.
        /// </summary>
        public Employee Employee { get; set; } = default!;

        /// <summary>
        /// Gets or sets the start time of the experience.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the experience.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the position held during the experience.
        /// </summary>
        public string Position { get; set; } = string.Empty;
    }
}
