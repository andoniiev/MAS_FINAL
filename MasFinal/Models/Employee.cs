namespace MasFinal.Models
{
    /// <summary>
    /// Represents an employee, inheriting from the Person class.
    /// </summary>
    public class Employee : Person
    {
        /// <summary>
        /// Gets or sets the ID of the company the employee is associated with.
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company the employee is associated with.
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Gets or sets the list of skills possessed by the employee.
        /// </summary>
        public ICollection<Skill>? SkillList { get; set; } = new List<Skill>();

        /// <summary>
        /// Gets or sets the list of work experiences of the employee.
        /// </summary>
        public ICollection<Experience>? ExperienceList { get; set; } = new List<Experience>();

        /// <summary>
        /// Gets or sets the list of certifications obtained by the employee.
        /// </summary>
        public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

        /// <summary>
        /// Gets or sets the list of educational qualifications of the employee.
        /// </summary>
        public ICollection<Education>? Educations { get; set; } = new List<Education>();

        /// <summary>
        /// Gets or sets the path or URL of the employee's CV (Curriculum Vitae).
        /// </summary>
        /// <value>
        /// The path of the employee's CV.
        /// </value>
        public string CV { get; set; } = string.Empty;
    }
}
