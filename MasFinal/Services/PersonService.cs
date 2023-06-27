namespace MasFinal.Services
{
    /// <summary>
    /// Service class for handling person-related operations.
    /// </summary>
    public class PersonService : IPersonService
    {
        /// <summary>
        /// Calculates the age based on the provided date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth of the person.</param>
        /// <returns>The calculated age.</returns>
        public int CalculateAge(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dateOfBirth.Year;

            if (currentDate.Month < dateOfBirth.Month ||
                (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age;
        }
    }
}
