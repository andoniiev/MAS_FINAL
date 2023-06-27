using MasFinal.Enums;

namespace MasFinal.Models
{
    /// <summary>
    /// Represents a person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the ID of the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PESEL (Personal Identification Number) of the person.
        /// </summary>
        public int Pesel { get; set; }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title or honorific for the person.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sex of the person.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the person.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
