namespace MasFinal.Models
{
    /// <summary>
    /// Represents a certification.
    /// </summary>
    public class Certification
    {
        /// <summary>
        /// Gets or sets the ID of the certification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the certification.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the organization that issued the certification.
        /// </summary>
        public string Organisation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category of the certification.
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}