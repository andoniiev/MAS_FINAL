namespace MasFinal.Models
{
    /// <summary>
    /// Represents a company.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Gets or sets the ID of the company.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the year the company was founded.
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// Gets or sets the website URL of the company.
        /// </summary>
        public string? CompanySite { get; set; }

        /// <summary>
        /// Gets or sets the list of postings associated with the company.
        /// </summary>
        public ICollection<Posting>? Postings { get; set; } = new List<Posting>();
    }
}
