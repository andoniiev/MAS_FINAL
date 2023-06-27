namespace MasFinal.Models
{
    /// <summary>
    /// Represents a posting.
    /// </summary>
    public class Posting
    {
        /// <summary>
        /// Gets or sets the ID of the posting.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the time when the posting was made.
        /// </summary>
        public DateTime PostingTime { get; set; }

        /// <summary>
        /// Gets or sets the text content of the posting.
        /// </summary>
        public string PostingText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the company associated with the posting.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company associated with the posting.
        /// </summary>
        public Company Company { get; set; } = default!;
    }
}
