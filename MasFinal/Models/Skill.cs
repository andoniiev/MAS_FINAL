namespace MasFinal.Models
{
    /// <summary>
    /// Represents a skill.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Gets or sets the ID of the skill.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the skill.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the skill.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category of the skill.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        public ICollection<Employee>? EmployeeList { get; set; } = new List<Employee>();
    }
}
