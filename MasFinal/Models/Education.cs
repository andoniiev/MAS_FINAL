namespace MasFinal.Models
{
    /// <summary>
    /// Represents an education entity.
    /// </summary>
    public class Education
    {
        /// <summary>
        /// Gets or sets the ID of the education entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the education entity.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets list of employees.
        /// </summary>
        public ICollection<Employee>? EmployeeList { get; set; } = new List<Employee>();
    }
}
