namespace MasFinal.Models
{
    /// <summary>
    /// Represents an employee's certification.
    /// </summary>
    public class EmployeeCertification
    {
        /// <summary>
        /// Gets or sets the ID of the employee certification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the employee associated with the certification.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee associated with the certification.
        /// </summary>
        public Employee Employee { get; set; } = default!;

        /// <summary>
        /// Gets or sets the ID of the certification.
        /// </summary>
        public int CertificationId { get; set; }

        /// <summary>
        /// Gets or sets the certification associated with the employee.
        /// </summary>
        public Certification Certification { get; set; } = default!;

        /// <summary>
        /// Gets or sets the date when the certification was acquired by the employee.
        /// </summary>
        public DateTime AcquisitonDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the certification is valid until.
        /// </summary>
        public DateTime ValidUntil { get; set; }
    }
}
