namespace MasFinal.Services
{
    /// <summary>
    /// Interface for person-related operations.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Calculates the age based on the provided date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth of the person.</param>
        /// <returns>The calculated age in years.</returns>
        int CalculateAge(DateTime dateOfBirth);
    }
}
