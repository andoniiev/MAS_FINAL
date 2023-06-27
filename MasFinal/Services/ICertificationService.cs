using MasFinal.Models;

namespace MasFinal.Services
{
    /// <summary>
    /// Interface for certification-related operations.
    /// </summary>
    public interface ICertificationService
    {
        /// <summary>
        /// Retrieves a list of employees who are certified with the specified certification.
        /// </summary>
        /// <param name="certificationId">The ID of the certification.</param>
        /// <returns>A list of employees who hold the specified certification.</returns>
        List<Employee> GetCertifiedUsers(int certificationId);

        /// <summary>
        /// Retrieves a list of employees who have an expired or not valid certification of the specified type.
        /// </summary>
        /// <param name="certificationId">The ID of the certification.</param>
        /// <returns>A list of employees with an expired or not valid certification.</returns>
        List<Employee> FindUsersWithNotValidCertification(int certificationId);
    }
}
